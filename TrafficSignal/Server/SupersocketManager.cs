﻿using log4net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrafficSignal.Models;
using TrafficSignal.MySqlContextDataModel;
using TrafficSignal.Server.Dao;
using TrafficSignal.Server.Enums;

namespace TrafficSignal.Server
{
    public class SupersocketManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SupersocketManager));
        private ConcurrentBag<CustomAppServer> _servers;
        private ConcurrentBag<ServerConfig> _serverConfigs;
        private ConcurrentDictionary<string, bool> _serverStates;
        private ConcurrentHashSet<int> _usedPorts;
        private ConcurrentBag<Device> _devices;
        private IMySqlContextUnitOfWork _dbContext;
        private DeviceAppServer _fixedPortServer;

        private static readonly ConcurrentDictionary<int, CancellationTokenSource> _cancellationTokenSources = new ConcurrentDictionary<int, CancellationTokenSource>();

        public SupersocketManager()
        {
            _servers = new ConcurrentBag<CustomAppServer>();
            _serverConfigs = new ConcurrentBag<ServerConfig>();
            _serverStates = new ConcurrentDictionary<string, bool>();
            _usedPorts = new ConcurrentHashSet<int>();
            _devices = new ConcurrentBag<Device>();
            _dbContext = UnitOfWorkSource.GetUnitOfWorkFactory().CreateUnitOfWork();
        }

        // 批量实例化服务器
        public void CreateServers(List<Device> devices)
        {
            if (devices == null || devices.Count == 0)
            {
                log.Error("The devices list cannot be null or empty.");
                throw new ArgumentException("The devices list cannot be null or empty.");
            }

            _devices = new ConcurrentBag<Device>(devices);

            foreach (var device in devices)
            {
                try
                {
                    if (_usedPorts.Contains(device.Port))
                    {
                        Console.WriteLine($"Port {device.Port} is already in use. Skipping creation of server {device.DeviceName}.");
                        log.Warn($"Port {device.Port} is already in use. Skipping creation of server {device.DeviceName}.");
                        continue;
                    }

                    var config = new ServerConfig
                    {
                        Name = device.DeviceName,
                        Ip = "Any",
                        Port = device.Port,
                        Mode = SocketMode.Tcp,
                        MaxConnectionNumber = 100,
                    };

                    var server = new CustomAppServer(device, _dbContext);
                    if (!server.Setup(config))
                    {
                        log.Error($"Failed to set up server {config.Name}");
                        throw new Exception($"Failed to set up server {config.Name}");
                    }

                    _servers.Add(server);
                    _serverConfigs.Add(config);
                    _serverStates[config.Name] = false; // Initial state is stopped
                    _usedPorts.Add(device.Port);

                    Console.WriteLine($"Server {config.Name} created successfully on port {device.Port}.");
                    log.Info($"Server {config.Name} created successfully on port {device.Port}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating server for device {device.DeviceName}: {ex.Message}");
                    log.Error($"Error creating server for device {device.DeviceName}: {ex.Message}");
                }
            }
        }

        // 创建固定端口服务器
        public void CreateFixedPortServer()
        {
            try
            {
                int port;
                string portStr = ConfigurationManager.AppSettings["ServerPort"];

                if (string.IsNullOrEmpty(portStr) || !int.TryParse(portStr, out port) || port <= 0 || port > 65535)
                {
                    log.Error("Invalid or missing 'ServerPort' configuration.");
                    throw new ConfigurationErrorsException("Invalid or missing 'ServerPort' configuration.");
                }

                var config = new ServerConfig
                {
                    Name = "DeviceServer",
                    Ip = "Any",
                    Port = port,
                    Mode = SocketMode.Tcp,
                    MaxConnectionNumber = 100
                };

                _fixedPortServer = new DeviceAppServer(config);
                if (!_fixedPortServer.Setup(config))
                {
                    log.Error("Failed to set up FixedPortServer");
                    throw new Exception("Failed to set up FixedPortServer");
                }

                if (!_fixedPortServer.Start())
                {
                    log.Error("Failed to start FixedPortServer");
                    throw new Exception("Failed to start FixedPortServer");
                }

                _fixedPortServer.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(HandleFixedPortRequest);

                Console.WriteLine($"FixedPortServer created and started successfully on port {port}.");
                log.Info($"FixedPortServer created and started successfully on port {port}.");
            }
            catch (ConfigurationErrorsException ex)
            {
                log.Error($"Configuration error: {ex.Message}");
                Console.WriteLine($"Configuration error: {ex.Message}");
            }
            catch (Exception ex)
            {
                log.Error($"Error creating FixedPortServer: {ex.Message}");
                Console.WriteLine($"Error creating FixedPortServer: {ex.Message}");
            }
        }

        // 批量启动服务器
        public async Task StartAllServersAsync()
        {
            var tasks = new List<Task>();
            foreach (var server in _servers)
            {
                if (_serverStates[server.Config.Name] == false)
                {
                    tasks.Add(StartServerAsync(server));
                }
            }
            await Task.WhenAll(tasks);
        }

        private Task StartServerAsync(AppServer server)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (server.Start())
                    {
                        _serverStates[server.Config.Name] = true;
                        Console.WriteLine($"Server {server.Config.Name} started successfully.");
                        log.Info($"Server {server.Config.Name} started successfully.");
                    }
                    else
                    {
                        log.Error($"Failed to start server {server.Config.Name}");
                        throw new Exception($"Failed to start server {server.Config.Name}");
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Error starting server {server.Config.Name}: {ex.Message}");
                    Console.WriteLine($"Error starting server {server.Config.Name}: {ex.Message}");
                }
            });
        }

        // 批量关闭服务器
        public async Task StopAllServersAsync()
        {
            var tasks = new List<Task>();
            foreach (var server in _servers)
            {
                if (_serverStates[server.Config.Name] == true)
                {
                    tasks.Add(StopServerAsync(server));
                }
            }
            await Task.WhenAll(tasks);
        }

        private Task StopServerAsync(AppServer server)
        {
            return Task.Run(() =>
            {
                try
                {
                    server.Stop();
                    _serverStates[server.Config.Name] = false;
                    Console.WriteLine($"Server {server.Config.Name} stopped successfully.");
                    log.Info($"Server {server.Config.Name} stopped successfully.");
                }
                catch (Exception ex)
                {
                    log.Error($"Error stopping server {server.Config.Name}: {ex.Message}");
                    Console.WriteLine($"Error stopping server {server.Config.Name}: {ex.Message}");
                }
            });
        }

        // 获取服务器列表
        public List<AppServer> GetServers()
        {
            return _servers.Cast<AppServer>().ToList();
        }

        // 获取服务器和客户端状态
        public string GetServerStatus(Device device)
        {
            var server = _servers.FirstOrDefault(s => s.Config.Port == device.Port);
            if (server == null)
            {
                device.CollectionState = "服务未创建";
                return "服务未创建";
            }

            if (!_serverStates[server.Config.Name])
            {
                device.CollectionState = "服务未开启";
                return "服务未开启";
            }

            if (server.SessionCount > 0)
            {
                device.CollectionState = "已连接";
                return "已连接";
            }
            else
            {
                device.CollectionState = "未连接";
                return "未连接";
            }
        }

        // 处理来自固定端口服务器的请求
        public void HandleFixedPortRequest(AppSession session, StringRequestInfo requestInfo)
        {
            try
            {
                // 参数应该已经被解析并存储在requestInfo.Parameters中
                var key = requestInfo.Key.Split(',');
                log.Debug($"Receive: {session.SocketSession.RemoteEndPoint} {string.Join(",", key)}");

                // 检查参数数量是否正确
                if (key.Length != 2)
                {
                    session.Send($"Error: Request format should be 'deviceGroup,num'. Message: {requestInfo.Key}");
                    log.Warn($"Invalid request format: {requestInfo.Key}");
                    return;
                }

                var deviceGroup = key[0];
                if (string.IsNullOrEmpty(deviceGroup))
                {
                    session.Send($"Error: Device group cannot be empty. Message: {requestInfo.Key}");
                    log.Warn($"Device group is empty: {requestInfo.Key}");
                    return;
                }

                // 检查num是否是一个整数
                if (!int.TryParse(key[1], out int num))
                {
                    session.Send($"Error: 'num' should be an integer. Message: {requestInfo.Key}");
                    log.Warn($"'num' is not an integer: {requestInfo.Key}");
                    return;
                }

                // 检查num是否在0到5之间
                if (num < 0 || num > 2)
                {
                    session.Send($"Error: 'num' should be between 0 and 2. Message: {requestInfo.Key}");
                    log.Warn($"'num' out of range: {requestInfo.Key}");
                    return;
                }

                // 查找所有匹配的设备
                var devices = _devices.Where(d => d.DeviceGroup == deviceGroup).ToList();
                if (devices.Count == 0)
                {
                    session.Send($"Error: No devices found with the group '{deviceGroup}'. Message: {requestInfo.Key}");
                    log.Warn($"No devices found for group: {deviceGroup}");
                    return;
                }

                // Log the received command
                if (num == 0)
                    log.Debug("绿灯");
                else if (num == 1)
                    log.Debug("黄灯");
                else if (num == 2)
                    log.Debug("红灯");
                else
                    log.Debug("未知指令");

                // 为每一个匹配的设备发送信息
                foreach (var device in devices)
                {
                    string message = GetCommandHexValueByDeviceType(device, num);

                    if (string.IsNullOrEmpty(message))
                    {
                        // 未知设备类型或没有找到对应的消息，跳过处理
                        log.Warn($"No command message for device type: {device.DeviceType}, id: {device.Id}");
                        continue;
                    }

                    if (device.DeviceType == "红绿灯" && num != 1)
                    {
                        // 终止黄灯闪烁
                        if (_cancellationTokenSources.TryRemove(device.Id, out var cts))
                        {
                            cts.Cancel();
                        }
                    }

                    log.Debug($"{device.DeviceName} {device.DeviceType} {device.DeviceGroup} {device.DeviceVersion} {message}");

                    ProcessAndSendMessagesAsync(device, message);
                }

                // 通知客户端所有消息已发送
                session.Send($"Success: Message sent to {devices.Count} devices.");
            }
            catch (Exception ex)
            {
                log.Error($"Error handling fixed port request: {ex.Message}");
                log.Error($"Received message: {requestInfo.Key}");
                Console.WriteLine($"Error handling fixed port request: {ex.Message}");
                session.Send($"Error: {ex.Message}");
            }
        }

        private string GetCommandHexValueByDeviceType(Device device, int num)
        {
            string message = string.Empty;

            // 根据设备类型获取对应的枚举值
            switch (device.DeviceType)
            {
                case "显示器":
                    if (device.DeviceVersion.Equals("大屏（横屏）"))
                    {
                        if (device.TestState.Equals("是") && num == 2)
                        {
                            message = "a5 68 32 ff 7b 01 1a 00 00 00 12 00 00 f5 00 00 03 07 ff 00 00 d0 c5 ba c5 b5 c6 b5 f7 0d 0a ca d4 d6 d0 00 d5 0d ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae";
                            break;
                        }
                        message = EnumHelper.GetScreenBigCommandHexValueByIntValue(num);
                    }
                    else if (device.DeviceVersion.Equals("小屏（竖屏）"))
                        message = EnumHelper.GetScreenSmallCommandHexValueByIntValue(num);
                    break;
                case "红绿灯":
                    message = EnumHelper.GetSignalCommandHexValueByIntValue(device, num);
                    break;
                case "声光报警器":
                    message = EnumHelper.GetAlarmCommandHexValueByIntValue(num);
                    break;
            }
            return message;
        }

        public async Task ProcessAndSendMessagesAsync(Device device, string message)
        {
            if (device.DeviceType.Equals("红绿灯"))
            {
                string printMsg = EnumHelper.ConvertToLightCommands(device, message);
                log.Debug(printMsg);
            }

            if (device.DeviceType.Equals("显示器"))
            {
                string printMsg = EnumHelper.ConvertToScreenCommands(device, message);
                log.Debug(printMsg);
            }

            var messageParts = message.Split(new[] { '&', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in messageParts)
            {
                await ProcessMessagePartAsync(device, part);
            }
        }

        private async Task ProcessMessagePartAsync(Device device, string part)
        {
            int delayTime = device.DeviceType.Equals("声光报警器") ? 7000 : 1000;

            if (part.Contains('&') || part.Contains(';') || part.Contains(','))
            {
                await ProcessAndSendMessagesAsync(device, part);
            }
            else
            {
                SendMessageToClient(device, part);
            }

            await Task.Delay(delayTime);
        }

        public string SendMessageToClient(Device device, string message)
        {
            var server = _servers.FirstOrDefault(s => s.Config.Port == device.Port);
            if (server == null)
            {
                return "服务未创建";
            }

            if (!_serverStates[server.Config.Name])
            {
                return "服务未开启";
            }

            if (server.SessionCount == 0)
            {
                return "没有客户端连接";
            }

            try
            {
                var sessions = server.GetAllSessions().ToList();
                if (!sessions.Any())
                {
                    return "没有找到客户端会话";
                }

                byte[] byteArray = StringToByteArray.Convert(message);
                foreach (var session in sessions)
                {
                    session.Send(byteArray, 0, byteArray.Length);
                }

                return "消息发送成功";
            }
            catch (Exception ex)
            {
                log.Error($"Error sending message to client: {ex.Message}");
                Console.WriteLine($"Error sending message to client: {ex.Message}");
                return $"消息发送失败: {ex.Message}";
            }
        }
    }
}
