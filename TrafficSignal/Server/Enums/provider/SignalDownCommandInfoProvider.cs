using System;
using System.Collections.Generic;

namespace TrafficSignal.Server.Enums
{
    public class SignalDownCommandInfoProvider : ICommandInfoProvider
    {
        public List<CommandInfo> GetCommandInfos()
        {
            var commandInfos = new List<CommandInfo>();

            foreach (SignalCommandEnum command in Enum.GetValues(typeof(SignalCommandEnum)))
            {
                commandInfos.Add(new CommandInfo
                {
                    Description = EnumHelper.GetEnumDescription(command),
                    HexValue = EnumHelper.SignalDownCommandHexValues.TryGetValue(command, out var hexValue) ? hexValue : string.Empty
                });
            }

            return commandInfos;
        }
    }
}