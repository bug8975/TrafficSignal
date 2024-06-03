using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using log4net;
using TrafficSignal.Models;

namespace TrafficSignal.Server.Enums
{
    public static class EnumHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EnumHelper));

        public static readonly Dictionary<ScreenCommandEnum, string> ScreenBigCommandHexValues = new Dictionary<ScreenCommandEnum, string>
        {
            { ScreenCommandEnum.NormalPassageGreen, "a5 68 32 ff 7b 01 14 00 00 00 12 00 00 05 00 00 03 07 00 ff 00 d5 fd b3 a3 cd a8 d0 d0 00 86 09 ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnSlowPassageYellow, "a5 68 32 ff 7b 01 1e 00 00 00 12 00 00 f5 00 00 03 07 ff ff 00 c7 b0 b7 bd bb fd cb aa 0e 0d 0a bb ba c2 fd cd a8 d0 d0 00 be 11 ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnNoPassageRed, "a5 68 32 ff 7b 01 1e 00 00 00 12 00 00 f5 00 00 03 07 ff 00 00 c7 b0 b7 bd bb fd cb aa 0e 0d 0a bd fb d6 b9 cd a8 d0 d0 00 d2 10 ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" },
            { ScreenCommandEnum.WaterAheadSlowPassageYellow, "a5 00 68 32 01 7b 01 1d 00 00 00 12 00 00 05 00 00 03 05 ff ff 00 c7 b0 b7 bd bb fd cb aa 0e 20 bb ba c2 fd cd a8 d0 d0 00 d6 0f ae" },
            { ScreenCommandEnum.WaterAheadNoPassageRed, "a5 00 68 32 01 7b 01 1d 00 00 00 12 00 00 05 00 00 03 05 ff 00 00 c7 b0 b7 bd bb fd cb aa 0e 20 bd fb d6 b9 cd a8 d0 d0 00 ea 0e ae" },
            { ScreenCommandEnum.SaveCommand, "A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" }
        };

        public static readonly Dictionary<ScreenCommandEnum, string> ScreenSmallCommandHexValues = new Dictionary<ScreenCommandEnum, string>
        {
            { ScreenCommandEnum.NormalPassageGreen, "a5 68 32 01 7b 01 14 00 00 00 12 00 00 05 00 00 03 05 00 ff 00 d5 fd b3 a3 cd a8 d0 d0 00 86 08 ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnSlowPassageYellow, "a5 68 32 01 7b 01 22 00 00 00 12 00 00 05 00 00 03 04 ff ff 00 c7 b0  bb ba 0d 0a b7 bd c2 fd 0d 0a bb fd  cd a8 0d 0a cb aa 0e d0 d0 00 ff 0f ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnNoPassageRed, "a5 68 32 01 7b 01 22 00 00 00 12 00 00 05 00 00 03 04 ff 00 00 c7 b0  bd fb 0d 0a b7 bd  d6 b9 0d 0a bb fd  cd a8 0d 0a cb aa 0e  d0 d0 00 13 0f ae,A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" },
            { ScreenCommandEnum.SaveCommand, "A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" }
        };

        public static readonly Dictionary<SignalCommandEnum, string> SignalCommandHexTemplates = new Dictionary<SignalCommandEnum, string>
        {
            { SignalCommandEnum.Green, "01 05 00 00 00 00 CD CA,01 05 00 01 00 00 9C 0A,01 05 00 02 00 00 6C 0A" },
            { SignalCommandEnum.Yellow, "01 05 00 00 FF 00 8C 3A,01 05 00 01 FF 00 DD FA,01 05 00 02 00 00 6C 0A" },
            { SignalCommandEnum.Red, "01 05 00 00 FF 00 8C 3A,01 05 00 01 00 00 9C 0A,01 05 00 02 FF 00 2D FA" },
            { SignalCommandEnum.Off, "01 05 00 00 FF 00 8C 3A,01 05 00 01 00 00 9C 0A,01 05 00 02 00 00 6C 0A" },
            { SignalCommandEnum.FlashingYellow, "01 05 00 00 FF 00 8C 3A,01 05 00 01 FF 00 DD FA,01 05 00 02 00 00 6C 0A;01 05 00 00 FF 00 8C 3A,01 05 00 01 00 00 9C 0A,01 05 00 02 00 00 6C 0A" },
        };

        public static readonly Dictionary<AlarmCommandEnum, string> AlarmCommandHexValues = new Dictionary<AlarmCommandEnum, string>
        {
            { AlarmCommandEnum.NormalPass, "01 06 00 10 00 00 88 0F" },
            { AlarmCommandEnum.PrimaryWarning, "01 06 00 12 01 01 E9 9F,01 06 00 10 00 03 C8 0E" },
            { AlarmCommandEnum.SecondaryWarning, "01 06 00 12 01 02 A9 9E,01 06 00 10 00 03 C8 0E" },
            { AlarmCommandEnum.SlowPass, "01 06 00 12 01 01 E9 9F" },
            { AlarmCommandEnum.NoPass, "01 06 00 12 01 02 A9 9E" },
            { AlarmCommandEnum.ActivateAlarm, "01 06 00 10 00 03 C8 0E" },
            { AlarmCommandEnum.DeactivateAlarm, "01 06 00 10 00 00 88 0F" },
            { AlarmCommandEnum.SetVolume10, "01 06 00 11 00 0A 59 C8" },
            { AlarmCommandEnum.SetVolume30, "01 06 00 11 00 1E 59 C7" },
        };

        public static string GetEnumDescription(System.Enum value)
        {
            try
            {
                FieldInfo field = value.GetType().GetField(value.ToString());
                DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
                return attribute == null ? value.ToString() : attribute.Description;
            }
            catch (Exception ex)
            {
                log.Error($"Error getting enum description for {value}", ex);
                return "Unknown";
            }
        }

        public static string GetScreenBigCommandHexValue(ScreenCommandEnum commandEnum)
        {
            if (!Enum.IsDefined(typeof(ScreenCommandEnum), commandEnum))
            {
                log.Warn($"Invalid ScreenCommandEnum value: {commandEnum}");
                return string.Empty;
            }

            try
            {
                return ScreenBigCommandHexValues.TryGetValue(commandEnum, out var bigHexValue) ? bigHexValue : throw new KeyNotFoundException($"ScreenCommandEnum value '{commandEnum}' not found.");
            }
            catch (Exception ex)
            {
                log.Error($"Error getting ScreenBigCommandHexValue for {commandEnum}", ex);
                return string.Empty;
            }
        }

        public static string GetScreenSmallCommandHexValue(ScreenCommandEnum commandEnum)
        {
            if (!Enum.IsDefined(typeof(ScreenCommandEnum), commandEnum))
            {
                log.Warn($"Invalid ScreenCommandEnum value: {commandEnum}");
                return string.Empty;
            }

            try
            {
                return ScreenSmallCommandHexValues.TryGetValue(commandEnum, out var smallHexValue) ? smallHexValue : throw new KeyNotFoundException($"ScreenCommandEnum value '{commandEnum}' not found.");
            }
            catch (Exception ex)
            {
                log.Error($"Error getting ScreenSmallCommandHexValue for {commandEnum}", ex);
                return string.Empty;
            }
        }

        public static string GenerateDynamicHexValue(SignalCommandEnum command, string laneAddress)
        {
            if (string.IsNullOrEmpty(laneAddress))
            {
                log.Warn("Lane address is null or empty");
                return string.Empty;
            }

            try
            {
                if (SignalCommandHexTemplates.TryGetValue(command, out var template))
                {
                    var subTemplates = template.Split(';');
                    var processedCommands = new List<string>();

                    foreach (var subTemplate in subTemplates)
                    {
                        var commands = subTemplate.Split(',');

                        for (int i = 0; i < commands.Length; i++)
                        {
                            var commandParts = commands[i].Split(' ');
                            if (commandParts.Length < 3)
                            {
                                log.Error($"Invalid command format: {commands[i]}");
                                return string.Empty;
                            }

                            // Remove the first part (original address) and the last two parts (CRC)
                            var commandWithoutAddressAndCrc = string.Join(" ", commandParts.Skip(1).Take(commandParts.Length - 3));

                            // Add lane address
                            var updatedCommand = $"{laneAddress} {commandWithoutAddressAndCrc}";

                            // Calculate and add new CRC
                            var newCrc = CrcCalculator.CalculateCrc(updatedCommand);
                            commands[i] = $"{updatedCommand} {newCrc}";
                        }

                        processedCommands.Add(string.Join(",", commands));
                    }

                    return string.Join(";", processedCommands);
                }
                else
                {
                    var message = $"SignalCommandEnum value '{command}' not found.";
                    log.Error(message);
                    throw new KeyNotFoundException(message);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error generating dynamic hex value for {command} with laneAddress {laneAddress}", ex);
                return string.Empty;
            }
        }

        public static string GetAlarmCommandHexValue(AlarmCommandEnum commandEnum)
        {
            if (!Enum.IsDefined(typeof(AlarmCommandEnum), commandEnum))
            {
                log.Warn($"Invalid AlarmCommandEnum value: {commandEnum}");
                return string.Empty;
            }

            try
            {
                return AlarmCommandHexValues.TryGetValue(commandEnum, out var hexValue) ? hexValue : throw new KeyNotFoundException($"AlarmCommandEnum value '{commandEnum}' not found.");
            }
            catch (Exception ex)
            {
                log.Error($"Error getting AlarmCommandHexValue for {commandEnum}", ex);
                return string.Empty;
            }
        }

        public static List<CommandInfo> GetAllCommandInfos(Device device)
        {
            if (device == null)
            {
                log.Warn("Device is null");
                return new List<CommandInfo>();
            }

            if (string.IsNullOrEmpty(device.DeviceType))
            {
                log.Warn("DeviceType is null or empty");
                return new List<CommandInfo>();
            }

            try
            {
                ICommandInfoProvider provider;

                switch (device.DeviceType)
                {
                    case "显示器":
                        switch (device.DeviceVersion)
                        {
                            case "大屏（横屏）":
                                provider = new ScreenBigCommandInfoProvider();
                                break;
                            case "小屏（竖屏）":
                                provider = new ScreenSmallCommandInfoProvider();
                                break;
                            default:
                                throw new NotSupportedException($"Unsupported DeviceVersion: {device.DeviceVersion}");
                        }
                        break;
                    case "声光报警器":
                        provider = new AlarmCommandInfoProvider();
                        break;
                    case "红绿灯":
                        provider = new SignalCommandInfoProvider(device);
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported DeviceType: {device.DeviceType}");
                }

                return provider.GetCommandInfos();
            }
            catch (Exception ex)
            {
                log.Error($"Error getting command infos for device {device.DeviceType} with version {device.DeviceVersion}", ex);
                return new List<CommandInfo>();
            }
        }

        public static string GetScreenBigCommandHexValueByIntValue(int intValue)
        {
            if (!Enum.IsDefined(typeof(ScreenCommandEnum), intValue))
            {
                log.Warn($"Invalid int value for ScreenCommandEnum: {intValue}");
                return string.Empty;
            }

            try
            {
                ScreenCommandEnum commandEnum = (ScreenCommandEnum)intValue;
                return GetScreenBigCommandHexValue(commandEnum);
            }
            catch (Exception ex)
            {
                log.Error($"Error getting ScreenBigCommandHexValue by int value {intValue}", ex);
                return string.Empty;
            }
        }

        public static string GetScreenSmallCommandHexValueByIntValue(int intValue)
        {
            if (!Enum.IsDefined(typeof(ScreenCommandEnum), intValue))
            {
                log.Warn($"Invalid int value for ScreenCommandEnum: {intValue}");
                return string.Empty;
            }

            try
            {
                ScreenCommandEnum commandEnum = (ScreenCommandEnum)intValue;
                return GetScreenSmallCommandHexValue(commandEnum);
            }
            catch (Exception ex)
            {
                log.Error($"Error getting ScreenSmallCommandHexValue by int value {intValue}", ex);
                return string.Empty;
            }
        }

        public static string GetAlarmCommandHexValueByIntValue(int intValue)
        {
            if (!Enum.IsDefined(typeof(AlarmCommandEnum), intValue))
            {
                log.Warn($"Invalid int value for AlarmCommandEnum: {intValue}");
                return string.Empty;
            }

            try
            {
                AlarmCommandEnum commandEnum = (AlarmCommandEnum)intValue;
                return GetAlarmCommandHexValue(commandEnum);
            }
            catch (Exception ex)
            {
                log.Error($"Error getting AlarmCommandHexValue by int value {intValue}", ex);
                return string.Empty;
            }
        }

        internal static string GetSignalCommandHexValueByIntValue(Device device, int intValue)
        {
            if (device == null)
            {
                log.Warn("Device is null");
                return string.Empty;
            }

            if (!Enum.IsDefined(typeof(SignalCommandEnum), intValue))
            {
                log.Warn($"Invalid int value for SignalCommandEnum: {intValue}");
                return string.Empty;
            }

            try
            {
                SignalCommandEnum commandEnum = (SignalCommandEnum)intValue;
                if (device.LaneAddresses == null)
                    device.LaneAddresses = "01";

                string[] messages = device.LaneAddresses.Split(',');
                for (int i = 0; i < messages.Length; i++)
                {
                    messages[i] = GenerateDynamicHexValue(commandEnum, messages[i]);
                }
                return string.Join("&", messages);
            }
            catch (Exception ex)
            {
                log.Error($"Error getting SignalCommandHexValue by int value {intValue} for device with addresses {device.LaneAddresses}", ex);
                return string.Empty;
            }
        }
    }
}