using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignal.Server.Enums
{
    public enum ScreenCommandEnum
    {
        [Description("正常通行 绿色")]
        NormalPassageGreen = 0,

        [Description("前方积水 回车 缓慢通行 黄色")]
        WaterAheadCarriageReturnSlowPassageYellow = 1,

        [Description("前方积水 回车 禁止通行 红色")]
        WaterAheadCarriageReturnNoPassageRed = 2,

        [Description("前方积水 缓慢通行 黄色")]
        WaterAheadSlowPassageYellow = 3,

        [Description("前方积水 禁止通行 红色")]
        WaterAheadNoPassageRed = 4,

        [Description("保存指令")]
        SaveCommand = 5,
    }

}