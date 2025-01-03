using UnityEngine;
using WRA.UI_Extensions.PanelsSystem;
using Zenject;

namespace WRA.UI_Extensions
{
    public class PanelManagerInstaller : MonoInstaller
    {
        [SerializeField] private PanelManager panelManager;
    
        public override void InstallBindings()
        {
            Container.Bind<PanelManager>().To<PanelManager>().FromInstance(panelManager).CopyIntoAllSubContainers();
        }
    }
}
