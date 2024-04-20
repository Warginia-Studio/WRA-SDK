using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

public class CustomPanelFactoryPlaceholder : IFactory<string, PanelBase>
{
    private List<PanelBase> _panelBases;
    private DiContainer _container;
    
    public CustomPanelFactoryPlaceholder(DiContainer container, List<PanelBase> panelBases)
    {
        _panelBases = panelBases;
        _container = container;
    }
    
    public PanelBase Create(string param)
    {
        Debug.Log("Create panel: "+param);
        foreach (var panelBase in _panelBases)
        {
            if (panelBase.name == param)
            {
                return _container.InstantiatePrefab(panelBase.gameObject).GetComponent<PanelBase>();
            }
        }
        return null;
    }
}
