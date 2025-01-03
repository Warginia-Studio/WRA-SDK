using System.Collections.Generic;
using WRA.UI_Extensions.PanelsSystem;
using WRA.Utility.Diagnostics.Logs;
using Zenject;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.UI_Extensions
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
                    Diagnostics.Log("Created panel: "+panelName, LogType.ok);
                    var panel = container.InstantiatePrefab(panelBase.gameObject, panelManager.transform).GetComponent<PanelBase>();
                    panel.name = panelName;
                    panel.InitPanelBase(data);
                    panel.OnCreate();
                    return panel;
                }
            }
            Diagnostics.Log("Create panel: "+panelName, LogType.failed);
            return null;
        }
    }
}
