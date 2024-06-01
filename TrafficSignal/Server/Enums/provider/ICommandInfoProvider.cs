using System.Collections.Generic;

namespace TrafficSignal.Server.Enums
{
    public interface ICommandInfoProvider
    {
        List<CommandInfo> GetCommandInfos();
    }

}