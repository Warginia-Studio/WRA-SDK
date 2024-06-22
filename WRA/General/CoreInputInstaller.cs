using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

public class CoreInputInstaller : MonoBehaviour
{
    [Inject] private PanelManager panelManager;
    private CoreInput coreInput;
    
    private PanelBase consolePanel;
    private PanelBase debugPanel;
    private void Awake()
    {
        consolePanel = panelManager.GetPanel("GameConsole");
        debugPanel = panelManager.GetPanel("DebugPanel");
        
        coreInput = new CoreInput();
        coreInput.Enable();
        coreInput.General.Console.performed += ctx => OnConsolePressed();
        coreInput.General.DebugPanel.performed += ctx => OnDebugPanelPressed();
    }
    
    private void OnConsolePressed()
    {
        if(consolePanel == null)
            consolePanel = panelManager.GetPanel("GameConsole");
        
        consolePanel.SwitchHideThisPanel();
    }
    
    private void OnDebugPanelPressed()
    {
        if(debugPanel == null)
            debugPanel = panelManager.GetPanel("DebugPanel");
        
        debugPanel.SwitchHideThisPanel();
    }
}
