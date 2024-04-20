using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

public class CustomPanelFactoryPlaceholder : IFactory<string, PanelDataBase, PanelBase>
{
    private readonly List<PanelBase> panelBases;
    private readonly DiContainer container;
    private readonly PanelManager panelManager;
    
    public CustomPanelFactoryPlaceholder(DiContainer container, List<PanelBase> panelBases, PanelManager panelManager)
    {
        this.panelBases = panelBases;
        this.container = container;
        this.panelManager = panelManager;
    }

    public PanelBase Create(string panelName, PanelDataBase data)
    {
        Debug.Log("Create panel: "+panelName);
        foreach (var panelBase in panelBases)
        {
            if (panelBase.name == panelName)
            {
                var panel = container.InstantiatePrefab(panelBase.gameObject, panelManager.transform).GetComponent<PanelBase>();
                panel.InitPanelBase(data);
                return panel;
            }
        }
        return null;
    }
}
