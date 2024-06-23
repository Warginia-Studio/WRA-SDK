using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.General.Patterns.Pool;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.General.SceneManagment
{
    public class SceneManagerHelper : MonoBehaviour
    {
        [SerializeField] private List<string> dontHidePanels;
        [Inject] private ILoadingScene sceneManager;
        [Inject] private PanelManager panelManager;
        [Inject] private List<IPool> pools;

        private void Awake()
        {
            // sceneManager = GetComponent<SceneManager>();
            sceneManager.OnSceneStartLoading.AddListener(OnSceneStartLoading);
            sceneManager.OnSceneReady.AddListener(HidePanels);
        }

        private void OnDestroy()
        {
            sceneManager.OnSceneStartLoading.RemoveListener(OnSceneStartLoading);
            sceneManager.OnSceneReady.RemoveListener(HidePanels);
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
}
