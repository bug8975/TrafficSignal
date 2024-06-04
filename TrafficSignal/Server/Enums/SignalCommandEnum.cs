using System.ComponentModel;

namespace TrafficSignal.Server.Enums
{
    public enum SignalCommandEnum
    {
        [Description("绿灯")]
        Green = 0,

        [Description("黄灯闪烁")]
        FlashingYellow = 11,

        [Description("红灯")]
        Red = 2,

        [Description("黄灯")]
        Yellow = 1,

        [Description("全灭")]
        Off = 12,
    }
}