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
        public string Usage => "Usage: cmd <open/close/switch>";
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
            if (command.ToLower() == "open")
            {
                panelManager.OpenPanel("GameConsole");
            }
            else if (command.ToLower() == "close")
            {
                panelManager.HidePanel("GameConsole");
            }
            else if(command.ToLower() == "switch")
            {
                var pan = panelManager.GetPanel("GameConsole");
                if(pan == null)
                    panelManager.OpenPanel("GameConsole");
                else
                    pan.SwitchHideThisPanel();
            }
            else
            {
                Logs.Diagnostics.Log(Usage, Logs.LogType.cmd);
            }
        }
    }
}
