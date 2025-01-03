using UnityEngine;
using WRA.UI_Extensions.PanelsSystem;
using WRA.Utility.Diagnostics.GameConsole;
using Zenject;

namespace WRA.General.ZenjectInstallers
{
    public class CoreInputInstaller : MonoBehaviour
    {
        [Inject] private PanelManager panelManager;
        private CoreInput coreInput;
    
        private WraGameConsole consolePanel;
        private PanelBase debugPanel;
    
        private void Awake()
        {
            InitInput();
        }

        private void InitInput()
        {
            if (coreInput != null)
                return;
            coreInput = new CoreInput();
            coreInput.Enable();
            coreInput.General.Console.performed += ctx => OnConsolePressed();
            coreInput.General.DebugPanel.performed += ctx => OnDebugPanelPressed();
        }
    
        private void OnConsolePressed()
        {
            if (consolePanel == null)
            {
                consolePanel = panelManager.ShowPanel("GameConsole") as WraGameConsole;
                return;
            }

            if(consolePanel.IsEditing)
                return;
        
            consolePanel.PanelActionsFragment.SwitchHideThisPanel();
        }
    
        private void OnDebugPanelPressed()
        {
            if(debugPanel== null)
                debugPanel = panelManager.GetPanel("DiagnosticsPanel");
        
            debugPanel.PanelActionsFragment.SwitchHideThisPanel();
        }
    }
}
