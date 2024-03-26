using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Diagnostics.GameConsole;
using WRA.Utility.Diagnostics.Logs;

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
            WraDiagnostics.Log(command.Name + " - " + command.Description, "commands");
        }
    }
}
