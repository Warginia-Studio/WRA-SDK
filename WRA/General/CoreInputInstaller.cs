using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.GameConsole;
using Zenject;

public class CoreInputInstaller : MonoBehaviour
{
    [Inject] private PanelManager panelManager;
    private CoreInput coreInput;
    
    private WraGameConsole consolePanel;
    private PanelBase debugPanel;
    private void Awake()
    {
        coreInput = new CoreInput();
        coreInput.Enable();
        coreInput.General.Console.performed += ctx => OnConsolePressed();
        coreInput.General.DebugPanel.performed += ctx => OnDebugPanelPressed();
    }
    
    private void OnConsolePressed()
    {
        if(consolePanel == null)
            consolePanel = panelManager.OpenPanel("GameConsole") as WraGameConsole;
        
        if(consolePanel.IsEditing)
            return;
        
        consolePanel.SwitchHideThisPanel();
    }
    
    private void OnDebugPanelPressed()
    {
        if(debugPanel == null)
            debugPanel = panelManager.OpenPanel("DebugPanel");
        
        debugPanel.SwitchHideThisPanel();
    }
}
