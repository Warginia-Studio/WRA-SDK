using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns.Singletons;
using WRA.UI.PanelsSystem;
using Zenject;

public class SceneManagerProxy : MonoBehaviourSingletonMustExist<SceneManagerProxy>, ILoadingStatus
{
    [Inject] private PanelManager panelManager;
    
    [SerializeField] private bool useProgressScreen = true;
    [SerializeField] private bool autoStartScene = true;
    
    private AsyncOperation asyncOperation;

    private void Awake()
    {
        if(instance== null)
            instance = this;
    }

    public void LoadScene(string sceneName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        
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
}
