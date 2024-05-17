using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace WRA.UI.PanelsSystem.Zenject
{
    public class PanelFactory : PlaceholderFactory<string, PanelDataBase, PanelBase>
    {
        private readonly List<PanelBase> panelBases;
        private readonly DiContainer container;
        private readonly PanelManager panelManager;
        
        public PanelFactory(DiContainer container, List<PanelBase> panelBases, PanelManager panelManager)
        {
            this.panelBases = panelBases;
            this.container = container;
            this.panelManager = panelManager;
        }
        
        public override PanelBase Create(string panelName, PanelDataBase data)
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
}
