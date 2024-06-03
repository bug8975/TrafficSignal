using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using TrafficSignal.Models;

namespace TrafficSignal.Server.Enums
{
    public class SignalCommandInfoProvider : ICommandInfoProvider
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SignalCommandInfoProvider));
        public Device Device { get; private set; }

        public SignalCommandInfoProvider(Device device)
        {
            if (device == null)
            {
                log.Error("Device is null during initialization");
                throw new ArgumentNullException(nameof(device), "Device cannot be null");
            }

            if (string.IsNullOrEmpty(device.LaneAddresses))
            {
                log.Error("Device.LaneAddresses is null or empty during initialization");
                throw new ArgumentException("Device.LaneAddresses cannot be null or empty", nameof(device));
            }

            this.Device = device;
            log.Info("SignalCommandInfoProvider initialized successfully");
        }

        public List<CommandInfo> GetCommandInfos()
        {
            var commandInfos = new List<CommandInfo>();

            try
            {
                string[] laneAddresses = Device.LaneAddresses.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (!laneAddresses.Any())
                {
                    log.Warn("No valid lane addresses found in device");
                    return commandInfos;
                }

                foreach (SignalCommandEnum command in Enum.GetValues(typeof(SignalCommandEnum)))
                {
                    string hexValue = GenerateHexValueForCommand(command, laneAddresses);
                    commandInfos.Add(new CommandInfo
                    {
                        Description = EnumHelper.GetEnumDescription(command),
                        HexValue = hexValue
                    });
                }
            }
            catch (Exception ex)
            {
                log.Error("Error occurred while getting command infos", ex);
            }

            return commandInfos;
        }

        private string GenerateHexValueForCommand(SignalCommandEnum command, string[] laneAddresses)
        {
            var hexList = new List<string>();
            foreach (var address in laneAddresses)
            {
                try
                {
                    string hexValue = EnumHelper.GenerateDynamicHexValue(command, address);
                    hexList.Add(hexValue);
                }
                catch (Exception ex)
                {
                    log.Error($"Error generating hex value for command {command} with address {address}", ex);
                }
            }
            return string.Join("&", hexList);
        }
    }
}