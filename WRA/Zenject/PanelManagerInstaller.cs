using UnityEngine;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.Zenject
{
    public class PanelManagerInstaller : MonoInstaller
    {
        [SerializeField] private PanelManager panelManager;
    
        public override void InstallBindings()
        {
            Container.Bind<PanelManager>().FromInstance(panelManager).AsSingle();
        }
    }
}
