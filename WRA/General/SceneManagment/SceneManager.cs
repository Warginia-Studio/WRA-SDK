using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using WRA.General.Patterns.Singletons;
using WRA.UI_Extensions.PanelsSystem;
using Zenject;

namespace WRA.General.SceneManagment
{
    public class SceneManager : MonoBehaviour, ILoadingScene
    {
        public UnityEvent OnSceneStartLoading { get; } = new UnityEvent();
        public UnityEvent OnSceneReady { get; } = new UnityEvent();
        public UnityEvent OnSceneStart { get; } = new UnityEvent();
        
        public LoadingStatus Status { get; private set; } = LoadingStatus.Running;
        
        [SerializeField] private PanelManager panelManager;
        
        [SerializeField] private bool useProgressScreen = true;
        [SerializeField] private bool autoStartScene = true;
    
        private AsyncOperation asyncOperation;

        private void Awake()
        {
            
        }

        public void LoadScene(string sceneName)
        {
            Status = LoadingStatus.Loading;
            OnSceneStartLoading.Invoke();
            asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = autoStartScene;
            
            if(useProgressScreen)
                panelManager.ShowPanel("ProgressPanel", new PanelDataBase() { Data = this });
            
            StartCoroutine(SceneLoadedEnumerator());
        }
        
        public void LoadScene(int sceneIndex)
        {
            Status = LoadingStatus.Loading;
            OnSceneStartLoading.Invoke();
            asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = autoStartScene;
            
            if(useProgressScreen)
                panelManager.ShowPanel("ProgressPanel", new PanelDataBase() { Data = this });
            
            StartCoroutine(SceneLoadedEnumerator());
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
        
        private void OnLoadComplete(AsyncOperation operation)
        {
            Status = LoadingStatus.Running;
            OnSceneReady.Invoke();
        }

        private IEnumerator SceneLoadedEnumerator()
        {
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
            
            panelManager.ClosePanel("ProgressPanel");
            Status = LoadingStatus.Running;
        }
    }
}
