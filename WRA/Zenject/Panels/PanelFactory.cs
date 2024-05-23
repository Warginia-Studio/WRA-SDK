using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.Logs;
using Zenject;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.Zenject.Panels
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
            Diagnostics.Log("Creating panel: "+ panelName);
            foreach (var panelBase in panelBases)
            {
                if (panelBase.name == panelName)
                {
                    Diagnostics.Log("[ SUCCESS ] Create panel: "+panelName);
                    var panel = container.InstantiatePrefab(panelBase.gameObject, panelManager.transform).GetComponent<PanelBase>();
                    panel.InitPanelBase(data);
                    return panel;
                }
            }
            Diagnostics.Log("Create panel: "+panelName, LogType.failed);
            return null;
        }
    }
}
