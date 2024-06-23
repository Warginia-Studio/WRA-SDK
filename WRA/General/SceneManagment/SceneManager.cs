using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using WRA.General.Patterns.Singletons;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.General.SceneManagment
{
    public class SceneManager : MonoInstaller, ILoadingScene
    {
        public UnityEvent OnSceneStartLoading { get; } = new UnityEvent();
        public UnityEvent OnSceneReady { get; } = new UnityEvent();
        public UnityEvent OnSceneStart { get; } = new UnityEvent();
        
        public LoadingStatus Status { get; private set; } = LoadingStatus.Running;
        
        [SerializeField] private PanelManager panelManager;
        
        [SerializeField] private bool useProgressScreen = true;
        [SerializeField] private bool autoStartScene = true;
    
        private AsyncOperation asyncOperation;

        public override void InstallBindings()
        {
            Container.Bind<ILoadingScene>().To<ILoadingScene>().FromInstance(this);
        }

        private void Update()
        {
            
        }

        public void LoadScene(string sceneName)
        {
            Status = LoadingStatus.Loading;
            OnSceneStartLoading.Invoke();
            asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        
            if(useProgressScreen)
                panelManager.OpenPanel("ProgressPanel", new PanelDataBase() { Data = this });
        
            asyncOperation.allowSceneActivation = autoStartScene;
        }
        
        public void LoadScene(int sceneIndex)
        {
            Status = LoadingStatus.Loading;
            OnSceneStartLoading.Invoke();
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
            if(useProgressScreen)
                panelManager.ClosePanel("ProgressPanel");
            Status = LoadingStatus.Running;
            OnSceneStart.Invoke();
        }

        public bool IsReady()
        {
            if(asyncOperation == null)
                return false;
            
            var ready = asyncOperation.progress >= 0.9f;
            if(ready)
            {
                Status = LoadingStatus.Ready;
                OnSceneReady.Invoke();
            }
            return ready;
        }

        public float GetProgress()
        {
            if(asyncOperation == null)
                return 0;
            return asyncOperation.progress / 0.9f;
        }
    }
}
