using System;
using System.Collections.Generic;

namespace TrafficSignal.Server.Enums
{
    public class ScreenSmallCommandInfoProvider : ICommandInfoProvider
    {
        public List<CommandInfo> GetCommandInfos()
        {
            var commandInfos = new List<CommandInfo>();

            foreach (ScreenCommandEnum command in Enum.GetValues(typeof(ScreenCommandEnum)))
            {
                commandInfos.Add(new CommandInfo
                {
                    Description = EnumHelper.GetEnumDescription(command),
                    HexValue = EnumHelper.GetScreenSmallCommandHexValue(command)
                });
            }

            return commandInfos;
        }
    }
}