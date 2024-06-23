using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns.Pool;
using WRA.General.SceneManagment;
using WRA.UI.PanelsSystem;
using Zenject;

public class SceneManagerHelper : MonoBehaviour
{
    [SerializeField] private List<string> dontHidePanels;
    [Inject] private ILoadingScene sceneManager;
    [Inject] private PanelManager panelManager;
    [Inject] private List<IPool> pools;

    private void Awake()
    {
        sceneManager.OnSceneStartLoading.AddListener(OnSceneStartLoading);
    }

    private void OnDestroy()
    {
        sceneManager.OnSceneStartLoading.RemoveListener(OnSceneStartLoading);
    }

    private void OnSceneStartLoading()
    {
        HidePanels();
        foreach (var pool in pools)
        {
            pool.KillAll();
        }
        
        
    }
    
    private void HidePanels()
    {
        foreach (var panel in panelManager.GetPanels())
        {
            if (!dontHidePanels.Contains(panel.name))
            {
                panel.HideThisPanel();
            }
        }
    }
}
