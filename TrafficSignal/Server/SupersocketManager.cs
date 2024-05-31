﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrafficSignal.Models;
using TrafficSignal.Server.Enums;

namespace TrafficSignal.Server
{
    public class SupersocketManager
    {
        private List<CustomAppServer> _servers;
        private List<ServerConfig> _serverConfigs;
        private Dictionary<string, bool> _serverStates;
        private HashSet<int> _usedPorts;
        private List<Device> _devices;
        private MySqlContext _dbContext;
        private DeviceAppServer _fixedPortServer;

        private static readonly ConcurrentDictionary<int, CancellationTokenSource> _cancellationTokenSources = new ConcurrentDictionary<int, CancellationTokenSource>();

        public SupersocketManager(MySqlContext dbContext)
        {
            _servers = new List<CustomAppServer>();
            _serverConfigs = new List<ServerConfig>();
            _serverStates = new Dictionary<string, bool>();
            _usedPorts = new HashSet<int>();
            _devices = new List<Device>();
            _dbContext = dbContext;
        }

        // 批量实例化服务器
        public void CreateServers(List<Device> devices)
        {
            if (devices == null || devices.Count == 0)
            {
                throw new ArgumentException("The devices list cannot be null or empty.");
            }

            _devices = devices;

            foreach (var device in devices)
            {
                try
                {
                    if (_usedPorts.Contains(device.Port))
                    {
                        Console.WriteLine($"Port {device.Port} is already in use. Skipping creation of server {device.DeviceName}.");
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
                        throw new Exception($"Failed to set up server {config.Name}");
                    }

                    _servers.Add(server);
                    _serverConfigs.Add(config);
                    _serverStates[config.Name] = false; // Initial state is stopped
                    _usedPorts.Add(device.Port);

                    Console.WriteLine($"Server {config.Name} created successfully on port {device.Port}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating server for device {device.DeviceName}: {ex.Message}");
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
                    throw new Exception("Failed to set up FixedPortServer");
                }

                if (!_fixedPortServer.Start())
                {
                    throw new Exception("Failed to start FixedPortServer");
                }

                _fixedPortServer.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(HandleFixedPortRequest);

                Console.WriteLine($"FixedPortServer created and started successfully on port {port}.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Configuration error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating FixedPortServer: {ex.Message}");
            }
        }

        // 批量启动服务器
        public async Task StartAllServersAsync()
        {
            var tasks = new List<Task>();
            foreach (var server in _servers)
            {
                if (!_serverStates[server.Config.Name])
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
                    }
                    else
                    {
                        throw new Exception($"Failed to start server {server.Config.Name}");
                    }
                }
                catch (Exception ex)
                {
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
                if (_serverStates[server.Config.Name])
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
                }
                catch (Exception ex)
                {
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

        // 向客户端发送消息
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
                Task.Delay(50); // 确保每条消息有时间发送

                return "消息发送成功";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message to client: {ex.Message}");
                return $"消息发送失败: {ex.Message}";
            }
        }


        // 处理来自固定端口服务器的请求
        public void HandleFixedPortRequest(AppSession session, StringRequestInfo requestInfo)
        {
            try
            {
                // 参数应该已经被解析并存储在requestInfo.Parameters中
                var key = requestInfo.Key.Split(',');

                // 检查参数数量是否正确
                if (key.Length != 2)
                {
                    session.Send("Error: Request format should be 'deviceGroup,num'.");
                    return;
                }

                var deviceGroup = key[0];
                if (string.IsNullOrEmpty(deviceGroup))
                {
                    session.Send("Error: Device group cannot be empty.");
                    return;
                }

                // 检查num是否是一个整数
                if (!int.TryParse(key[1], out int num))
                {
                    session.Send("Error: 'num' should be an integer.");
                    return;
                }

                // 检查num是否在0到5之间
                if (num < 0 || num > 5)
                {
                    session.Send("Error: 'num' should be between 0 and 5.");
                    return;
                }

                // 查找所有匹配的设备
                var devices = _devices.Where(d => d.DeviceGroup == deviceGroup).ToList();
                if (devices.Count == 0)
                {
                    session.Send($"Error: No devices found with the group '{deviceGroup}'.");
                    return;
                }

                // 为每一个匹配的设备发送信息
                foreach (var device in devices)
                {
                    string message = GetCommandHexValueByDeviceType(device, num);

                    if (string.IsNullOrEmpty(message))
                    {
                        // 未知设备类型或没有找到对应的消息，跳过处理
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

                    ProcessAndSendMessages(device, message);
                }

                // 通知客户端所有消息已发送
                session.Send($"Success: Message sent to {devices.Count} devices.");
            }
            catch (Exception ex)
            {
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
                case "显示屏":
                    if (device.DeviceVersion.Equals("大屏（横屏）"))
                        message = EnumHelper.GetScreenBigCommandHexValueByIntValue(num);
                    else if (device.DeviceVersion.Equals("小屏（竖屏）"))
                        message = EnumHelper.GetScreenSmallCommandHexValueByIntValue(num);
                    break;
                case "红绿灯":
                    if (device.DeviceGroup.Equals("UP"))
                        message = EnumHelper.GetSignalUpCommandHexValueByIntValue(num);
                    else if (device.DeviceGroup.Equals("DOWN"))
                        message = EnumHelper.GetSignalDownCommandHexValueByIntValue(num);
                    break;
                case "声光报警器":
                    message = EnumHelper.GetAlarmCommandHexValueByIntValue(num);
                    break;
            }
            return message;
        }

        private void ProcessAndSendMessages(Device device, string message)
        {
            if (!message.Contains(",") && !message.Contains(";"))
            {
                // 第一种情况：message中不包含逗号和分号
                SendMessageToClient(device, message);
            }
            else if (message.Contains(",") && !message.Contains(";"))
            {
                // 第二种情况：message中包含逗号且不包含分号
                var messages = message.Split(',');
                foreach (var msg in messages)
                {
                    SendMessageToClient(device, msg.Trim());
                }
            }
            else if (message.Contains(";"))
            {
                // 启动黄灯闪烁模式
                var cts = new CancellationTokenSource();
                _cancellationTokenSources[device.Id] = cts;
                StartFlashingYellowLight(device, message, cts.Token);
            }
        }

        private void StartFlashingYellowLight(Device device, string message, CancellationToken token)
        {
            Task.Run(async () =>
            {
                var groups = message.Split(';');
                while (!token.IsCancellationRequested)
                {
                    foreach (var group in groups)
                    {
                        var messages = group.Split(',');
                        foreach (var msg in messages)
                        {
                            SendMessageToClient(device, msg.Trim());
                        }
                        await Task.Delay(1000, token);
                    }
                }
            }, token);
        }
    }
}