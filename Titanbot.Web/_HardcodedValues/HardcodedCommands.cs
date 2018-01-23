using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titanbot.Web.Models;
using Titanbot.Web.Models.CommandModels;
using Titanbot.Web.Models.CommandModels.Enums;

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
                new Command
                {
                    Name = "Invite",
                    Description = "Provides a link to invite me to any guild",
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$invite - Shows the invite link"
                    }
                },
                new Command
                {
                    Name = "Ping",
                    Description = "Basic command for calculating my delay.",
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$ping - Replies with a pong and what the current delay is."
                    }
                },
                new Command
                {
                    Name = "Prefix",
                    Description = "Gets or sets a custom prefix that is required to use my commands",
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Administrator,
                    Usages = new List<string>
                    {
                        "t$prefix - Gets all the available current prefixes",
                        "t$prefix <newPrefix> - Sets the custom prefix"
                    }
                },
                new Command
                {
                    Name = "About",
                    Description = "A tiny command that just displays some helpful links :)",
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$about - Shows some about text for me"
                    }
                },
                new Command
                {
                    Name = "Donate",
                    Description = "You.. youre thinking of donating? :O This command will give you a link to my patreon page",
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$donate - Gives you the link you awesome person <3"
                    }
                },
                new Command
                {
                    Name = "Formatting",
                    Description = "Command used to see and use all the available output formats",
                    Aliases = new List<string>
                    {
                        "Format", "Output"
                    },
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$formatting - Lists all the formatting options available to you",
                        "t$formatting Use <format> - Sets what formatting style to use for your commands"
                    }
                },
                new Command
                {
                    Name = "Languages",
                    Description = "Shows information about any and all languages supported by me",
                    Aliases = new List<string>
                    {
                        "Language", "Locale"
                    },
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$languages Export <language> - Exports a given language into a json file for you to download",
                        "t$languages Import <language> - Imports an attached file as the given language",
                        "t$languages Reload - Reloads the language data from file",
                        "t$languages Use <language> - Sets the language you would like to use",
                        "t$languages - Lists all the available languages for you to use."
                    }
                },
                //new Command
                //{
                //    Name = "RemindMe",
                //    Description = "No description!",
                //    Group = CommandGroup.General,
                //    DefaultPerm = DefaultPerms.Everyone,
                //    Usages = new List<string>
                //    {
                //        "t$remindme <duration> <message> -"
                //    }
                //},
                new Command
                {
                    Name = "Preferences",
                    Description = "Allows you to set some options for how I will interact with you.",
                    Aliases = new List<string>
                    {
                        "Pref", "Preference"
                    },
                    Group = CommandGroup.General,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$preferences [settingGroup] - Lists all preferences that are available",
                        "t$preferences Toggle <key> - Toggles the given preference. Only works for true/false/yes/no preferences",
                        "t$preferences Set <key> [value] - Sets the given preference to the given value"
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
                new Command
                {
                    Name = "Settings",
                    Description = "Allows the retrieval and changing of existing settings for the server",
                    Aliases = new List<string>
                    {
                        "Setting"
                    },
                    Group = CommandGroup.Admin,
                    DefaultPerm = DefaultPerms.Administrator,
                    Usages = new List<string>
                    {
                        "t$settings [settingGroup] - Lists all settings available",
                        "t$settings Toggle <key> - Toggles the given setting. Only works for true/false/yes/no settings",
                        "t$settings Set <key> [value] - Sets the given setting to the given value."
                    }
                },
                new Command
                {
                    Name = "SettingsReset",
                    Description = "Resets all settings and command permissions for a guild.",
                    Group = CommandGroup.Admin,
                    DefaultPerm = DefaultPerms.Administrator,
                    Usages = new List<string>
                    {
                        "t$settingsreset - Resets settings for this guild",
                        "t$settingsreset <guildId> - Resets the given guild"
                    }
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
                new Command
                {
                    Name = "Claim",
                    Description = "Used to tie your discord account to your ingame account. Will be used in the future for API access",
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$claim <supportCode> - Claims a support code as your own."
                    }
                },
                new Command
                {
                    Name = "ClanStats",
                    Description = "Shows various information for any clan with given attributes",
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$clanstats <clanLevel> -sta - Shows data about a clan with the given level"
                    },
                    Flags = new List<CommandFlag>
                    {
                        new CommandFlag
                        {
                            ShortInvokation = 's',
                            Invokation = "stage",
                            Description = "Average max stage to use",
                            Arguments = new List<string>
                            {
                                "averageMs"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 't',
                            Invokation = "taps",
                            Description = "Average taps to use",
                            Arguments = new List<string>
                            {
                                "tapsPerCQ"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 'a',
                            Invokation = "attackers",
                            Description = " Number of attackers to use (array)",
                            Arguments = new List<string>
                            {
                                "attackers..."
                            }
                        }
                    }
                },
                new Command
                {
                    Name = "Equipments",
                    Description = "Displays data about any equipment",
                    Aliases = new List<string>
                    {
                        "Equip", "Equips", "Equipment"
                    },
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$equipment List [equipClass] - Lists all equipment for the given type",
                        "t$equipment <equipment> [level] - Shows stats for a given equipment on the given level."
                    }
                },
                new Command
                {
                    Name = "Hero",
                    Description = "Displays data about any hero",
                    Aliases = new List<string>
                    {
                        "Helper"
                    },
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$hero List -g - Lists all heros available",
                        "t$hero <helper> [from] [to] - Shows stats for a given hero on the given level"
                    },
                    Flags = new List<CommandFlag>
                    {
                        new CommandFlag
                        {
                            ShortInvokation = 'g',
                            Invokation = "group",
                            Description = "Orders the heroes rather than grouping them"
                        }
                    }
                },
                new Command
                {
                    Name = "HighScore",
                    Description = "Shows data from the high score sheet, which can be found here. All credit to @◢T2◢ LiLau#5715, @Bloodstrife#3312 and @/T2/Marzx13#0979 for running the sheet!",
                    Aliases = new List<string>
                    {
                        "HS"
                    },
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$highscore [from] [to] - Shows the people in the specified range. Defaults to 1-30"
                    }
                },
                new Command
                {
                    Name = "Pets",
                    Description = "Displays data about any pet",
                    Aliases = new List<string>
                    {
                        "Pet"
                    },
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$pets <pet> [level] - Shows stats for a given pet on the given level",
                        "t$pets List - Lists all pets available"
                    }
                },
                new Command
                {
                    Name = "Prestige",
                    Description = "Shows you exactly what prestiging at a given point will mean for you",
                    Group = CommandGroup.Data,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$prestige <stage> -bci - Shows various stats about prestiging on the given stage"
                    },
                    Flags = new List<CommandFlag>
                    {
                        new CommandFlag
                        {
                            ShortInvokation = 'b',
                            Invokation = "bos",
                            Description = "Uses the given BoS level",
                            Arguments = new List<string>
                            {
                                "bosLevel"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 'c',
                            Invokation = "clan",
                            Description = "Uses the given clan level",
                            Arguments = new List<string>
                            {
                                "clanLevel"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 'i',
                            Invokation = "ip",
                            Description = "Uses the given IP level",
                            Arguments = new List<string>
                            {
                                "ipLevel"
                            }
                        }
                    }
                },

                // Clan
                new Command
                {
                    Name = "Apply",
                    Description = "Allows a user to register their interest in joining the clan",
                    Aliases = new List<string>
                    {
                        "R", "Reg", "Register"
                    },
                    Group = CommandGroup.Clan,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$apply <maxStage> <message> -girat - Creates your application for this clan",
                        "t$apply View -g - Views your registration for this guild",
                        "t$apply View <user> -g - View the registration for the given user",
                        "t$apply Cancel - Cancels your registration for this guild",
                        "t$apply Remove <user> - Removes the registration for the given user",
                        "t$apply Ignore <user> [ignore] - Specifies if a users global registrations should be ignored. Defaults to yes",
                        "t$apply List [start] [end] -g - Lists all applications for this guild",
                        "t$apply Clear - Completely clears your guilds application list"
                    },
                    Flags = new List<CommandFlag>
                    {
                        new CommandFlag
                        {
                            ShortInvokation = 'g',
                            Invokation = "global",
                            Description = "Specifies that the application is a global application."
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 'i',
                            Invokation = "images",
                            Description = "Specifies a list of images to use with your application",
                            Arguments = new List<string>
                            {
                                "images"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 'r',
                            Invokation = "relics",
                            Description = "Specifies how many relics you have earned",
                            Arguments = new List<string>
                            {
                                "relics"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 'a',
                            Invokation = "attacks",
                            Description = "Specifies how many attacks you aim to do per week",
                            Arguments = new List<string>
                            {
                                "attacks"
                            }
                        },
                        new CommandFlag
                        {
                            ShortInvokation = 't',
                            Invokation = "taps",
                            Description = "Specifies how many taps you average per CQ",
                            Arguments = new List<string>
                            {
                                "taps"
                            }
                        }
                    }
                },
                new Command
                {
                    Name = "Excuse",
                    Description = "Missed the boss? Or did someone else? Use this to get a water-tight excuse whenever you need!",
                    Group = CommandGroup.Clan,
                    DefaultPerm = DefaultPerms.Everyone,
                    Usages = new List<string>
                    {
                        "t$excuse [user] -i - Gets an excuse for why that person (or yourself) didnt attack the boss",
                        "t$excuse Add <text> - Adds an excuse to the pool of available excuses",
                        "t$excuse Remove <id> - Removes an excuse you made by ID"
                    },
                    Flags = new List<CommandFlag>
                    {
                        new CommandFlag
                        {
                            ShortInvokation = 'i',
                            Invokation = "id",
                            Description = "Specifies an ID to use",
                            Arguments = new List<string>
                            {
                                "excuseId"
                            }
                        }
                    }
                },

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
