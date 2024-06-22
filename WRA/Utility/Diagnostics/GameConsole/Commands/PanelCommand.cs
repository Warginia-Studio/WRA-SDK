using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.UI.PanelsSystem.PanelAnimations;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class PanelCommand : ICommand
    {
        public string Name => "panel";
        public string Description => "Show or hide panel";
        public string Usage => "panel <action> <panelName>";
        public List<string> Arguments { get; } = new List<string>()
        {
            "open - Open panel",
            "close - Close panel",
            "switch - Switch panel",
            "hide - Hide panel",
            "show - Show panel",
            "list - List all panels",
            "lo - List all open panels",
            "lh - List all hidden panels"
        };

        public void Execute(params string[] args)
        {
            if(args.Length <= 1)
            {
                Logs.Diagnostics.Log(Usage, Logs.LogType.cmd);
                return;
            }
            
            var panelManager = GameObject.FindObjectOfType<PanelManager>();
            if (panelManager == null)
            {
                Logs.Diagnostics.Log("PanelManager not found", Logs.LogType.cmd);
                return;
            }

            var panelName = args.Length > 2 ? args[2] : "";
            var action = args[1];

            if (action.ToLower() == "open")
            {
                panelManager.OpenPanel(panelName);
            }
            else if (action.ToLower() == "close")
            {
                panelManager.HidePanel(panelName);
            }
            else if (action.ToLower() == "switch")
            {
                var panel = GetPanel(panelName);
                panel?.SwitchHideThisPanel();
            }
            else if (action.ToLower() == "hide")
            {
                panelManager.HidePanel(panelName);
            }
            else if (action.ToLower() == "show")
            {
                panelManager.ShowPanel(panelName);
            }
            else if (action.ToLower() == "lo")
            {
                var panels = panelManager.GetPanels();
                Logs.Diagnostics.Log("Open panels:");
                PrintPanels(panels);
            }
            else if (action.ToLower() == "lh")
            {
                var panels = panelManager.GetPanels().FindAll(ctg =>
                    ctg.GetStatus() == PanelAnimationStatus.Hide ||
                    ctg.GetStatus() == PanelAnimationStatus.HidingAnimation);
                Logs.Diagnostics.Log("Hidden panels:");
                PrintPanels(panels);
            }
            else
            {
                Logs.Diagnostics.Log(Usage, Logs.LogType.cmd);
            }
        }
        
        private void PrintPanels(List<PanelBase> panels)
        {
            foreach (var panel in panels)
            {
                Logs.Diagnostics.Log(panel.gameObject.name);
            }
        }
        
        private PanelBase GetPanel(string panelName)
        {
            var panelManager = GameObject.FindObjectOfType<PanelManager>();
            if (panelManager == null)
            {
                Logs.Diagnostics.Log("PanelManager not found", Logs.LogType.cmd);
                return null;
            }

            return panelManager.GetPanel(panelName);
        }
    }
}
