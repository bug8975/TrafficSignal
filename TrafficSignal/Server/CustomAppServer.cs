using log4net;
using SuperSocket.SocketBase;
using System;
using TrafficSignal.Models;

namespace TrafficSignal.Server
{
    public class CustomAppServer : AppServer
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CustomAppServer));
        private Device _device;
        private MySqlContext _dbContext;

        public CustomAppServer(Device device, MySqlContext dbContext)
        {
            _device = device;
            _dbContext = dbContext;
        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            UpdateDeviceState(_device.Id, "已连接");
        }

        protected override void OnSessionClosed(AppSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            UpdateDeviceState(_device.Id, "未连接");
        }

        private void UpdateDeviceState(int deviceId, string state)
        {
            var device = _dbContext.Device.Find(deviceId);
            if (device != null)
            {
                device.CollectionState = state;
                _dbContext.SaveChanges();
                Console.WriteLine($"Device {device.DeviceName} state updated to {state}.");
                log.Info($"Device {device.DeviceName} state updated to {state}.");
            }
            else
            {
                Console.WriteLine($"Device with ID {deviceId} not found.");
                log.Warn($"Device with ID {deviceId} not found.");
            }
        }

    }
}