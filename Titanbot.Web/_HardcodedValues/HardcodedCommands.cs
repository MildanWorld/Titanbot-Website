using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titanbot.Web.Models;
using Titanbot.Web.Models.Enums;

namespace Titanbot.Web._HardcodedValues
{
    public class HardcodedCommands
    {
        public List<Command> Commands { get; set; }

        public HardcodedCommands()
        {
            Commands = new List<Command>
            {
                // The commands are listed by groups and then by alphabetical order
                // (actually just as Titanbot spews them out)

                // General
                new Command
                {
                    Name = "Help",
                    Description = "Displays help for any command",
                    Aliases = new List<string>(),
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$help [command] - Displays a list of all commands, or help for a single command"
                    }
                },
                new Command
                {
                    Name = "Info",
                    Description = "Displays some technical information about me",
                    Aliases = new List<string>(),
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$info - Displays technical info for me"
                    }
                },

                // Admin

                // Owner
                // Not yet?

                // Data

                // Clan

                // Bot
                new Command
                {
                    Name = "Report",
                    Description = "Allows you to report a bug you have found in me!",
                    Aliases = new List<string>(),
                    Group = CommandGroup.Bot,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$report <message> - Sends a bug report to my home guild."
                    }
                },
                new Command
                {
                    Name = "Suggest",
                    Description = "Allows you to make suggestions and feature requests for me!",
                    Aliases = new List<string>(),
                    Group = CommandGroup.Bot,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$suggest <message> - Sends a suggestion to my home guild."
                    }
                }
            };
        }
    }
}
