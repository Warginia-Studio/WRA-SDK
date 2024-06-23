using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns.Singletons;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.General.SceneManagment
{
    public class SceneManager : MonoInstaller, ILoadingStatus
    {
        [SerializeField] private PanelManager panelManager;

        [SerializeField] private List<string> dontHidePanels;
        
        [SerializeField] private bool useProgressScreen = true;
        [SerializeField] private bool autoStartScene = true;
    
        private AsyncOperation asyncOperation;

        public override void InstallBindings()
        {
            Container.Bind<ILoadingStatus>().FromInstance(this);
        }

        public void LoadScene(string sceneName)
        {
            asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        
            if(useProgressScreen)
                panelManager.OpenPanel("ProgressPanel", new PanelDataBase() { Data = this });
        
            asyncOperation.allowSceneActivation = autoStartScene;
        }
        
        public void LoadScene(int sceneIndex)
        {
            asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        
            if(useProgressScreen)
                panelManager.OpenPanel("ProgressPanel", new PanelDataBase() { Data = this });
        
            asyncOperation.allowSceneActivation = autoStartScene;
        }

        public void StartScene()
        {
            if(asyncOperation == null)
                return;
            asyncOperation.allowSceneActivation = true;
        }

        public bool IsReady()
        {
            if(asyncOperation == null)
                return false;
            return asyncOperation.progress >= 0.99f;
        }

        public float GetProgress()
        {
            if(asyncOperation == null)
                return 0;
            return asyncOperation.progress / 0.9f;
        }
        
        private void HidePanels()
        {
            var panels = panelManager.GetPanels();
            foreach (var panel in panels)
            {
                if (dontHidePanels.Contains(panel.name))
                    continue;
                panelManager.ClosePanel(panel.name);
            }
        }
    }
}
