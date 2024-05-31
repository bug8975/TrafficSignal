using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignal.Server.Enums
{
    public class SignalUpCommandInfoProvider : ICommandInfoProvider
    {
        public List<CommandInfo> GetCommandInfos()
        {
            var commandInfos = new List<CommandInfo>();

            foreach (SignalCommandEnum command in Enum.GetValues(typeof(SignalCommandEnum)))
            {
                commandInfos.Add(new CommandInfo
                {
                    Description = EnumHelper.GetEnumDescription(command),
                    HexValue = EnumHelper.SignalUpCommandHexValues.TryGetValue(command, out var hexValue) ? hexValue : string.Empty
                });
            }

            return commandInfos;
        }
    }
}