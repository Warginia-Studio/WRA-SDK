using UnityEngine;
using Zenject;

namespace WRA.UI.PanelsSystem.Zenject
{
    [CreateAssetMenu(fileName = "PanelFactoryInstaller", menuName = "thief01/WRA-SDK/Installers/PanelFactoryInstaller")]
    public class PanelFactoryInstaller : ScriptableObjectInstaller<PanelFactoryInstaller>
    {
        public override void InstallBindings()
        {
        
        }
    }
}
