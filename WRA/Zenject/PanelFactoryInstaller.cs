using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.Logs;
using Zenject;

namespace WRA.Zenject
{
    [CreateAssetMenu(fileName = "PanelFactoryInstaller", menuName = "thief01/WRA-SDK/Installers/PanelFactoryInstaller")]
    public class PanelFactoryInstaller : ScriptableObjectInstaller<PanelFactoryInstaller>
    {
        [SerializeField] private string[] dictionaryPaths = new []{ "SDK/Panels/" };
        [SerializeField] private string[] panelsNames = new[] { "WraGameConsole", "FadeManager" };
        private List<PanelBase> panels;
        public override void InstallBindings()
        {
            LoadPanels();
            Container.Bind < List<PanelBase>>().FromInstance(panels);
            // Container.Bind<PanelManager>().FromInstance(FindFirstObjectByType<PanelManager>());
            Container.BindFactory<string, PanelDataBase, PanelBase, PanelFactory>().FromFactory<PanelFactory>();
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

            WraDiagnostics.Log("loaded panels: " + panels.Count, "PanelFactoryInstaller");
        }
    }
}
