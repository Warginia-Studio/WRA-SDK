using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.Zenject.Panels
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
