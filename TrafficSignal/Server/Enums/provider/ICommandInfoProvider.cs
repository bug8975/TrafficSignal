using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSignal.Server.Enums;

namespace TrafficSignal.Server.Enums
{
    public interface ICommandInfoProvider
    {
        List<CommandInfo> GetCommandInfos();
    }

}