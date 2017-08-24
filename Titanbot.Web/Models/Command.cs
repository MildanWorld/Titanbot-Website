using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titanbot.Web.Models.Enums;

namespace Titanbot.Web.Models
{
    public class Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Aliases { get; set; } = new List<string>();
        public CommandGroup Group { get; set; }
        public DefaultPerms DefaultPerm { get; set; }
        public List<string> Usages { get; set; } = new List<string>();
        public List<CommandFlag> Flags { get; set; } = new List<CommandFlag>();
        public string Notes { get; set; }
    }
}