using System.Collections.Generic;
using System.Linq;
using Titanbot.Web.Models;
using Titanbot.Web.Models.CommandModels;
using Titanbot.Web.Models.CommandModels.Enums;

namespace Titanbot.Web.ViewModels
{
    public class AllCommands
    {
        public List<Command> Commands { get; set; }

        public List<CommandGroup> PriorityGroups => new List<CommandGroup>
        {
            CommandGroup.General,
            CommandGroup.Admin,
            CommandGroup.Clan,
            CommandGroup.Data,
            CommandGroup.Bot
        };
    }
}
