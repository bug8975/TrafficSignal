using log4net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;

namespace TrafficSignal.Server
{
    public class DeviceAppServer : AppServer
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DeviceAppServer));
        private ServerConfig _serverConfig;

        public DeviceAppServer(ServerConfig serverConfig)
        {
            _serverConfig = serverConfig;
        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            UpdateDeviceState("已连接");
        }

        protected override void OnSessionClosed(AppSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            UpdateDeviceState("未连接");
        }

        private void UpdateDeviceState(string state)
        {
            Console.WriteLine($"Device {_serverConfig.Name} state updated to {state}.");
            log.Warn($"Device {_serverConfig.Name} state updated to {state}.");
        }
    }
}