using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using TrafficSignal.Models;

namespace TrafficSignal.Server.Enums
{
    public static class EnumHelper
    {
        public static readonly Dictionary<ScreenCommandEnum, string> ScreenBigCommandHexValues = new Dictionary<ScreenCommandEnum, string>
        {
            { ScreenCommandEnum.NormalPassageGreen, "a5 68 32 ff 7b 01 14 00 00 00 12 00 00 05 00 00 03 07 00 ff 00 d5 fd b3 a3 cd a8 d0 d0 00 86 09 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnSlowPassageYellow, "a5 68 32 ff 7b 01 1e 00 00 00 12 00 00 f5 00 00 03 07 ff ff 00 c7 b0 b7 bd bb fd cb aa 0e 0d 0a bb ba c2 fd cd a8 d0 d0 00 be 11 ae " },
            { ScreenCommandEnum.WaterAheadCarriageReturnNoPassageRed, "a5 68 32 ff 7b 01 1e 00 00 00 12 00 00 f5 00 00 03 07 ff 00 00 c7 b0 b7 bd bb fd cb aa 0e 0d 0a bd fb d6 b9 cd a8 d0 d0 00 d2 10 ae" },
            { ScreenCommandEnum.WaterAheadSlowPassageYellow, "a5 00 68 32 01 7b 01 1d 00 00 00 12 00 00 05 00 00 03 05 ff ff 00 c7 b0 b7 bd bb fd cb aa 0e 20 bb ba c2 fd cd a8 d0 d0 00 d6 0f ae" },
            { ScreenCommandEnum.WaterAheadNoPassageRed, "a5 00 68 32 01 7b 01 1d 00 00 00 12 00 00 05 00 00 03 05 ff 00 00 c7 b0 b7 bd bb fd cb aa 0e 20 bd fb d6 b9 cd a8 d0 d0 00 ea 0e ae" },
            { ScreenCommandEnum.SaveCommand, "A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" }
        };

        public static readonly Dictionary<ScreenCommandEnum, string> ScreenSmallCommandHexValues = new Dictionary<ScreenCommandEnum, string>
        {
            { ScreenCommandEnum.NormalPassageGreen, "a5 00 68 32 01 7b 01 26 00 00 00 12 00 00 05 00 00 03 03 ff ff 00 c7 b0 20 bb ba 0d 0a b7 bd 20 c2 fd 0d 0a bb fd 20 cd a8 0d 0a cb aa 0e 20 d0 d0 00 82 10 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnSlowPassageYellow, "a5 68 32 01 7b 01 26 00 00 00 12 00 00 05 00 00 03 03 ff ff 00 c7 b0 20 bb ba 0d 0a b7 bd 20 c2 fd 0d 0a bb fd 20 cd a8 0d 0a cb aa 0e 20 d0 d0 00 7e 10 ae" },
            { ScreenCommandEnum.WaterAheadCarriageReturnNoPassageRed, "a5 00 68 32 01 7b 01 26 00 00 00 12 00 00 05 00 00 03 03 ff 00 00 c7 b0 20 bd fb 0d 0a b7 bd 20 d6 b9 0d 0a bb fd 20 cd a8 0d 0a cb aa 0e 20 d0 d0 00 96 0f ae" },
            { ScreenCommandEnum.SaveCommand, "A5 68 32 01 7B 01 04 00 00 00 07 00 00 00 22 01 ae" }
        };

        public static readonly Dictionary<SignalCommandEnum, string> SignalUpCommandHexValues = new Dictionary<SignalCommandEnum, string>
        {
            { SignalCommandEnum.Green, "01 05 00 00 00 00 CD CA,01 05 00 01 00 00 9C 0A,01 05 00 02 00 00 6C 0A" },
            { SignalCommandEnum.Yellow, "01 05 00 00 FF 00 8C 3A,01 05 00 01 FF 00 DD FA,01 05 00 02 00 00 6C 0A" },
            { SignalCommandEnum.Red, "01 05 00 00 FF 00 8C 3A,01 05 00 01 00 00 9C 0A,01 05 00 02 FF 00 2D FA" },
            { SignalCommandEnum.Off, "01 05 00 00 FF 00 8C 3A,01 05 00 01 00 00 9C 0A,01 05 00 02 00 00 6C 0A" },
            { SignalCommandEnum.FlashingYellow, "01 05 00 00 FF 00 8C 3A,01 05 00 01 FF 00 DD FA,01 05 00 02 00 00 6C 0A;01 05 00 00 FF 00 8C 3A,01 05 00 01 00 00 9C 0A,01 05 00 02 00 00 6C 0A" },
        };

        public static readonly Dictionary<SignalCommandEnum, string> SignalDownCommandHexValues = new Dictionary<SignalCommandEnum, string>
        {
            { SignalCommandEnum.Green, "02 05 00 00 00 00 CD F9,02 05 00 01 00 00 9C 39,02 05 00 02 00 00 6C 39" },
            { SignalCommandEnum.Yellow, "02 05 00 00 FF 00 8C 09,02 05 00 01 FF 00 DD C9,02 05 00 02 00 00 6C 39" },
            { SignalCommandEnum.Red, "02 05 00 00 FF 00 8C 09,02 05 00 01 00 00 9C 39,02 05 00 02 FF 00 2D C9" },
            { SignalCommandEnum.Off, "02 05 00 00 FF 00 8C 09,02 05 00 01 00 00 9C 39,02 05 00 02 00 00 6C 39" },
            { SignalCommandEnum.FlashingYellow, "02 05 00 00 FF 00 8C 09,02 05 00 01 FF 00 DD C9,02 05 00 02 00 00 6C 39;02 05 00 00 FF 00 8C 09,02 05 00 01 00 00 9C 39,02 05 00 02 00 00 6C 39" },
        };

        public static readonly Dictionary<AlarmCommandEnum, string> AlarmCommandHexValues = new Dictionary<AlarmCommandEnum, string>
        {
            { AlarmCommandEnum.SlowPass, "01 06 00 12 01 01 E9 9F" },
            { AlarmCommandEnum.NoPass, "01 06 00 12 01 02 A9 9E" },
            { AlarmCommandEnum.NormalPass, "01 06 00 10 00 00 88 0F" },
            { AlarmCommandEnum.ActivateAlarm, "01 06 00 10 00 03 C8 0E" },
            { AlarmCommandEnum.DeactivateAlarm, "01 06 00 10 00 00 88 0F" },
            { AlarmCommandEnum.SetVolume10, "01 06 00 11 00 0A 59 C8" },
            { AlarmCommandEnum.SetVolume30, "01 06 00 11 00 1E 59 C7" },
            { AlarmCommandEnum.PrimaryWarning, "01 06 00 12 01 01 E9 9F,01 06 00 10 00 03 C8 0E" },
            { AlarmCommandEnum.SecondaryWarning, "01 06 00 12 01 02 A9 9E,01 06 00 10 00 03 C8 0E" },
        };

        public static string GetEnumDescription(System.Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetScreenBigCommandHexValue(ScreenCommandEnum commandEnum)
        {
            return ScreenBigCommandHexValues.TryGetValue(commandEnum, out var bigHexValue) ? bigHexValue : string.Empty;
        }

        public static string GetScreenSmallCommandHexValue(ScreenCommandEnum commandEnum)
        {
            return ScreenSmallCommandHexValues.TryGetValue(commandEnum, out var smallHexValue) ? smallHexValue : string.Empty;
        }

        public static string GetSignalUpCommandHexValue(SignalCommandEnum commandEnum)
        {
            return SignalUpCommandHexValues.TryGetValue(commandEnum, out var upHexValue) ? upHexValue : string.Empty;
        }

        public static string GetSignalDownCommandHexValue(SignalCommandEnum commandEnum)
        {
            return SignalDownCommandHexValues.TryGetValue(commandEnum, out var downHexValue) ? downHexValue : string.Empty;
        }

        public static string GetAlarmCommandHexValue(AlarmCommandEnum commandEnum)
        {
            return AlarmCommandHexValues.TryGetValue(commandEnum, out var hexValue) ? hexValue : string.Empty;
        }

        public static List<CommandInfo> GetAllCommandInfos(Device device)
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
                    switch (device.DeviceGroup)
                    {
                        case "UP":
                            provider = new SignalUpCommandInfoProvider();
                            break;
                        case "DOWN":
                            provider = new SignalDownCommandInfoProvider();
                            break;
                        default:
                            throw new NotSupportedException($"Unsupported DeviceGroup: {device.DeviceGroup}");
                    }
                    break;
                default:
                    throw new NotSupportedException($"Unsupported DeviceType: {device.DeviceType}");
            }

            return provider.GetCommandInfos();
        }

        public static string GetScreenBigCommandHexValueByIntValue(int intValue)
        {
            ScreenCommandEnum commandEnum = (ScreenCommandEnum)intValue;
            return GetScreenBigCommandHexValue(commandEnum);
        }

        public static string GetScreenSmallCommandHexValueByIntValue(int intValue)
        {
            ScreenCommandEnum commandEnum = (ScreenCommandEnum)intValue;
            return GetScreenSmallCommandHexValue(commandEnum);
        }

        public static string GetSignalUpCommandHexValueByIntValue(int intValue)
        {
            SignalCommandEnum commandEnum = (SignalCommandEnum)intValue;
            return GetSignalUpCommandHexValue(commandEnum);
        }

        public static string GetSignalDownCommandHexValueByIntValue(int intValue)
        {
            SignalCommandEnum commandEnum = (SignalCommandEnum)intValue;
            return GetSignalDownCommandHexValue(commandEnum);
        }

        public static string GetAlarmCommandHexValueByIntValue(int intValue)
        {
            AlarmCommandEnum commandEnum = (AlarmCommandEnum)intValue;
            return GetAlarmCommandHexValue(commandEnum);
        }
    }
}