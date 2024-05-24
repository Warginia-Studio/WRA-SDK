
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WRA.Zenject.Commands;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Description => "Show all available commands";
        public string Usage => "help ";
        
        public List<string> Arguments => new List<string>()
        {
            "-us - Show usage of command",
            ""
        };

        public void Execute(string[] args)
        {
            var commands = GameObject.FindObjectsByType<CommandsInstallerBase>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).First().Commands;
            if (args.Length == 0)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    ShowCommand(commands[i]);
                }

                return;
            }

            var arg1 = args[1];
            ICommand command;
            if (arg1 == "-us")
            {
                if (args.Length == 2)
                {
                    Logs.Diagnostics.Log("Usage: help -us <command>", LogType.cmd, "commands");
                    return;
                }

                var commandName = args[2];
                command = commands.Find(x => x.Name == commandName);
                if (command == null)
                {
                    Logs.Diagnostics.Log("Command not found", LogType.cmd, "commands");
                    return;
                }

                ShowAllAboutCommand(command);
            }
        }



        private void ShowCommand(ICommand command)
        {
            Logs.Diagnostics.Log(command.Name + " - " + command.Description, LogType.cmd, "commands");
        }

        
        private void ShowUsage(ICommand command)
        {
            Logs.Diagnostics.Log(command.Usage, LogType.cmd, "commands");
        }

        private void ShowArguments(ICommand command)
        {
            var args = "";
            for (int i = 0; i < command.Arguments.Count; i++)
            {
                args += command.Arguments[i] + "\n";
            }
            Logs.Diagnostics.Log(args, LogType.cmd, "commands");
        }
        
        private void ShowAllAboutCommand(ICommand command)
        {
            ShowUsage(command);
            ShowArguments(command);
        }
    }
}
