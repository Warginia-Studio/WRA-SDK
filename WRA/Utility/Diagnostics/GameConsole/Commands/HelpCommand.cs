
using WRA.Utility.Diagnostics.Logs;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Description => "Show all available commands";
        public string Usage => "help";

        public void Execute(string[] args)
        {
            var commands = WraGameConsole.Commands;
            foreach (var command in commands)
            {
                Logs.Diagnostics.Log(command.Name + " - " + command.Description, LogType.cmd, "commands");
            }
        }
    }
}
