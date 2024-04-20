using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace WRA.UI.PanelsSystem.Zenject
{
    [CreateAssetMenu(fileName = "PanelFactoryInstaller", menuName = "thief01/WRA-SDK/Installers/PanelFactoryInstaller")]
    public class PanelFactoryInstaller : ScriptableObjectInstaller<PanelFactoryInstaller>
    {
        [SerializeField] private string[] dictionaryPaths = new []{ "SDK/Panels/" };
        [SerializeField] private string[] panelsNames = new[] { "WraGameConsole", "FadeManager" };
        private List<PanelBase> panels;
        public override void InstallBindings()
        {
            Container.Bind<string>().WithId("TEST").FromInstance("XD");
            // Container.Bind<PanelBase>().AsSingle().NonLazy();
            LoadPanels();

            Container.Bind < List<PanelBase>>().FromInstance(panels);
            Container.BindFactory<string, PanelBase, PanelFactory>().FromFactory<CustomPanelFactoryPlaceholder>();
            // Container.BindFactory<IEnemy, EnemyFactory>().FromFactory<CustomEnemyFactory>().WithArguments();
        }
        
        private void LoadPanels()
        {
            panels=new List<PanelBase>();
            foreach (var path in dictionaryPaths)
            {
                var loadedPanels = Resources.LoadAll<PanelBase>(path);
                if (loadedPanels != null)
                {
                    panels.AddRange(loadedPanels);
                }
            }
            Debug.Log("loaded panels: "+panels.Count);
        }
    }
}
