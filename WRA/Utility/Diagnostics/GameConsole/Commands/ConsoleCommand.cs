using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.DiagnosticsPanel;
using Zenject;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class ConsoleCommand : ICommand
    {
        public string Name => "cmd";
        public string Description => "Description";
        public string Usage => "Usage: cmd tag";
        public List<string> Arguments { get; } = new List<string>()
        {
            "tag - Tag console"
        };
        
        private PanelManager panelManager;
        
        public void Execute(params string[] args)
        {
            if(args.Length == 0 || args.Length == 1)
            {
                Logs.Diagnostics.Log(Usage, Logs.LogType.cmd);
                return;
            }
            
            if(panelManager == null)
                panelManager = GameObject.FindObjectOfType<PanelManager>();
            
            var command = args[1];

            if (command.ToLower() == "tag")
            {
                if(args.Length == 2)
                {
                    Logs.Diagnostics.Log("Usage: cmd tag <tag>", Logs.LogType.cmd);
                    return;
                }
                
                var tag = args[2];
                var pan = panelManager.GetPanel("GameConsole") as WraGameConsole;
                pan?.SetTag(tag);
            }
            else
            {
                Logs.Diagnostics.Log(Usage, Logs.LogType.cmd);
            }
        }
    }
}
