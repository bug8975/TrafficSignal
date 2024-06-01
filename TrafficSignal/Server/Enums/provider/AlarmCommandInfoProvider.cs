using System;
using System.Collections.Generic;

namespace TrafficSignal.Server.Enums
{
    public class AlarmCommandInfoProvider : ICommandInfoProvider
    {
        public List<CommandInfo> GetCommandInfos()
        {
            var commandInfos = new List<CommandInfo>();

            foreach (AlarmCommandEnum command in Enum.GetValues(typeof(AlarmCommandEnum)))
            {
                commandInfos.Add(new CommandInfo
                {
                    Description = EnumHelper.GetEnumDescription(command),
                    HexValue = EnumHelper.GetAlarmCommandHexValue(command)
                });
            }

            return commandInfos;
        }
    }
}