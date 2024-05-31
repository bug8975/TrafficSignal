using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignal.Server.Enums
{
    public enum SignalCommandEnum
    {
        [Description("绿灯")]
        Green = 0,

        [Description("黄灯闪烁")]
        FlashingYellow = 1,

        [Description("红灯")]
        Red = 2,

        [Description("黄灯")]
        Yellow = 11,

        [Description("全灭")]
        Off = 12,
    }
}