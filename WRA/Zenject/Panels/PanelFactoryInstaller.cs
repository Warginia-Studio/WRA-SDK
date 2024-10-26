using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.Logs;
using Zenject;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.Zenject.Panels
{
    [CreateAssetMenu(fileName = "PanelFactoryInstaller", menuName = "thief01/WRA-SDK/Installers/PanelFactoryInstaller")]
    public class PanelFactoryInstaller : ScriptableObjectInstaller<PanelFactoryInstaller>
    {
        [SerializeField] private string[] dictionaryPaths = new []{ "SDK/Panels/" };
        // [SerializeField] private string[] panelsNames = new[] { "WraGameConsole", "FadeManager" };
        
        [SerializeField] private ResourcePaths resourcePaths;
        private List<PanelBase> panels;
        public override void InstallBindings()
        {
            LoadPanels();
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
                    loadedPanels.ToList().ForEach(ctg => panels.RemoveAll(ctg2 => ctg.name == ctg2.name));
                    panels.RemoveAll(ctg => ctg.name == loadedPanels[0].name);
                    panels.AddRange(loadedPanels);
                }
            }
            
            Container.Bind<List<PanelBase>>().FromInstance(panels);

            Diagnostics.Log($"loaded panels: {panels.Count}", LogType.log, "PanelFactoryInstaller");
        }
    }
}
