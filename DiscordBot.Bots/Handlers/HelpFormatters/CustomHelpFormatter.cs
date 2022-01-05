﻿namespace DiscordBot.Bots.Handlers.HelpFormatters
{
    public class CustomHelpFormatter : BaseHelpFormatter
    {
        protected DiscordEmbedBuilder _embed;
        private readonly RPGContext _context;
        protected List<CustomCommand> CustomCommands;
        protected Command currentCommand;

        public CustomHelpFormatter(CommandContext ctx, RPGContext context) : base(ctx)
        {
            _context = context;
            _embed = new DiscordEmbedBuilder
            {
                Title = "GG-Bot Commands:",
                Color = DiscordColor.Gold,
            };

            List<CustomCommand> serverCommands = _context.CustomCommands.Where(x => x.GuildId == ctx.Guild.Id).OrderBy(x => x.Trigger).ToList();

            if(serverCommands.Any()) { CustomCommands = serverCommands; }
        }

        public override BaseHelpFormatter WithCommand(Command command)
        {
             _embed.AddField(command.Name, command.Description);

            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> cmds)
        {
            List<string> configCommands = new();
            List<string> customCommands = new();
            List<string> gameCommands = new();
            List<string> miscCommands = new();
            List<string> modCommands = new();
            List<string> nowLiveCommands = new();
            List<string> profileCommands = new();
            List<string> quoteCommands = new();
            List<string> reactionRoleCommands = new();
            List<string> streamerCommands = new();
            List<string> suggestionCommands = new();


            foreach (var cmd in cmds)
            {
                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("ConfigCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            configCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        configCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("CustomCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            customCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        customCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("GameCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            gameCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        gameCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("MiscCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            miscCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        miscCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("ModCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            modCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        modCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("NowLiveCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            nowLiveCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        nowLiveCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("ProfileCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            if (childCommand is CommandGroup childGroup)
                            {
                                var subchildCommands = childGroup.Children;

                                foreach (var subchildCommand in subchildCommands)
                                {
                                    profileCommands.Add($"`!{subchildCommand.QualifiedName}`");
                                }
                            }

                            else
                            {
                                profileCommands.Add($"`!{childCommand.QualifiedName}`");
                            }
                        }
                    }

                    else
                    {
                        nowLiveCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("QuoteCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            if (childCommand is CommandGroup childGroup)
                            {
                                var subchildCommands = childGroup.Children;

                                foreach (var subchildCommand in subchildCommands)
                                {
                                    quoteCommands.Add($"`!{subchildCommand.QualifiedName}`");
                                }
                            }

                            else
                            {
                                quoteCommands.Add($"`!{childCommand.QualifiedName}`");
                            }
                        }
                    }

                    else
                    {
                        quoteCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("ReactionRoleCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            reactionRoleCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        reactionRoleCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("StreamerCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            streamerCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        streamerCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }

                if (cmd.Module.ModuleType.UnderlyingSystemType.FullName.Contains("SuggestionCommands"))
                {
                    if (cmd is CommandGroup commandGroup)
                    {
                        var childCommands = commandGroup.Children;

                        foreach (var childCommand in childCommands)
                        {
                            suggestionCommands.Add($"`!{childCommand.QualifiedName}`");
                        }
                    }

                    else
                    {
                        suggestionCommands.Add($"`!{cmd.QualifiedName}`");
                    }
                }
            }

            if (configCommands.Count != 0)
            {
                _embed.AddField("Configuration Commands:", String.Join(", ", configCommands.ToArray()));
            }

            if (customCommands.Count != 0)
            {
                _embed.AddField("Custom Commands:", String.Join(", ", customCommands.ToArray()));
            }

            if (gameCommands.Count != 0)
            {
                _embed.AddField("Game Commands:", String.Join(", ", gameCommands.ToArray()));
            }

            if (miscCommands.Count != 0)
            {
                _embed.AddField("Misc Commands:", String.Join(", ", miscCommands.ToArray()));
            }

            if (modCommands.Count != 0)
            {
                _embed.AddField("Moderator Commands:", String.Join(", ", modCommands.ToArray()));
            }

            if (nowLiveCommands.Count != 0)
            {
                _embed.AddField("Now Live Commands:", String.Join(", ", nowLiveCommands.ToArray()));
            }

            if (profileCommands.Count != 0)
            {
                _embed.AddField("Profile Commands:", String.Join(", ", profileCommands.ToArray()));
            }

            if (quoteCommands.Count != 0)
            {
                _embed.AddField("Quote Commands:", String.Join(", ", quoteCommands.ToArray()));
            }

            if (reactionRoleCommands.Count != 0)
            {
                _embed.AddField("Reaction Role Commands:", String.Join(", ", reactionRoleCommands.ToArray()));
            }

            if (streamerCommands.Count != 0)
            {
                _embed.AddField("Streamer Commands:", String.Join(", ", streamerCommands.ToArray()));
            }

            if (suggestionCommands.Count != 0)
            {
                _embed.AddField("Suggestion Commands:", String.Join(", ", suggestionCommands.ToArray()));
            }

            return this;
        }

        public override CommandHelpMessage Build()
        {
            if (currentCommand == null)
            {
                List<string> serverSpecificCommands = new();

                _embed.WithDescription("Please find a full list of commands that are avaliable to you!");

                if (serverSpecificCommands.Count != 0)
                {
                    foreach (var ccmd in CustomCommands)
                    {
                        serverSpecificCommands.Add(ccmd.Trigger.Replace($"{ccmd.Trigger}", $"`{ccmd.Trigger}`"));
                    }

                    _embed.AddField("Server Specific Custom Commands:", String.Join(", ", serverSpecificCommands.ToArray()));
                }
            }

            else
            {
                _embed.WithDescription("Please find the specified commands below!");
            }

            return new CommandHelpMessage(embed: _embed);
        }
    }
}
