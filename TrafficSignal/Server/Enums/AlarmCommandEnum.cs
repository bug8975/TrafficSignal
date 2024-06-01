using System.ComponentModel;

namespace TrafficSignal.Server.Enums
{
    public enum AlarmCommandEnum
    {
        [Description("正常通行")]
        NormalPass = 0,

        [Description("一级预警")]
        PrimaryWarning = 1,

        [Description("二级预警")]
        SecondaryWarning = 2,

        [Description("缓慢通行")]
        SlowPass = 11,

        [Description("禁止通行")]
        NoPass = 12,

        [Description("打开警示灯报警器")]
        ActivateAlarm = 13,

        [Description("关闭警示灯报警器")]
        DeactivateAlarm = 14,

        [Description("设置音量为10")]
        SetVolume10 = 15,

        [Description("设置音量为30")]
        SetVolume30 = 16,
    }
}