using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.GameConsole;

public class ConsoleCommand : ICommand
{
    public string Name => "cmd";
    public string Description => "Description";
    public void Execute(params string[] args)
    {
        if(args.Length == 0)
        {
            Debug.Log("No arguments provided");
            return;
        }
        
        Debug.LogError(args[1]);
        Debug.LogError(args[0]);
        var command = args[1];
        if (command.ToLower() == "open")
        {
            PanelManager.Instance.ShowPanel<WraGameConsole>();
        }
        else if (command.ToLower() == "close")
        {
            PanelManager.Instance.HidePanel<WraGameConsole>();
        }
        else if(command.ToLower() == "switch")
        {
            PanelManager.Instance.GetPanel<WraGameConsole>().SwitchHideThisPanel();
        }
    }
}
