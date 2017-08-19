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
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$info - Displays technical info for me"
                    }
                },

                // Admin
                new Command
                {
                    Name = "EditCommand",
                    Description = "Used to allow people with varying roles or permissions to use different commands.",
                    Group = CommandGroup.Admin,
                    DefaultPerm = DefaultPerms.Administrator,
                    Usages = new List<string>
                    {
                        "t$editcommand SetRole <cmds...> [roles...] - Sets a list of roles required to use each command supplied",
                        "t$editcommand SetPerm <cmds...> [permission] - Sets a permission required to use each command supplied",
                        "t$editcommand Reset <cmds...> - Resets the roles and permissions required to use each command supplied",
                        "t$editcommand Blacklist <cmds...> <channels...> - Prevents anyone with permissions below the override permissions from using the command in the given channel"
                    },
                    Notes = "To work out just what permission id you need, give the permission calculator a try!"
                },

                // Owner
                // Not yet?

                // Data
                new Command
                {
                    Name = "Artifacts",
                    Description = "Displays data about any artifact",
                    Aliases = new List<string>
                    {
                        "Art", "Arts", "Artifact"
                    },
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$artifacts List - Lists all artifacts available.",
                        "t$artifacts Budget <artifact> <relics> [currentLevel] - Shows you what the maximum level you can get an artifact to is with a given relic budget",
                        "t$artifacts <artifact> [from] [to] - Shows stats for a given artifact on the given levels."
                    }
                },

                // Clan
                new Command
                {
                    Name = "TitanLord",
                    Description = "Used for Titan Lord timers and management",
                    Aliases = new List<string>
                    {
                        "TL", "Boss"
                    },
                    Group = CommandGroup.Clan,
                    DefaultPerm = DefaultPerms.Administrator,
                    Usages = new List<string>
                    {
                        "t$titanlord In <time> - Sets a Titan Lord timer running for the given period.",
                        "t$titanlord Dead - Sets a Titan Lord timer running for 6 hours.",
                        "t$titanlord Now - Alerts everyone that the Titan Lord is ready to be killed right now",
                        "t$titanlord When - Gets the time until the Titan Lord is ready to be killed",
                        "t$titanlord Info - Gets information about the clans current level",
                        "t$titanlord Stop - Stops any currently running timers."
                    }
                },

                // Bot
                new Command
                {
                    Name = "Report",
                    Description = "Allows you to report a bug you have found in me!",
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
