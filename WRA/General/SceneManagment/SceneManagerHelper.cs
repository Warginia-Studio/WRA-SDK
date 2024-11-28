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
        [Inject] private SceneManager sceneManager;
        [Inject] private PanelManager panelManager;
        [Inject] private List<IPool> pools;

        private void Awake()
        {
            // sceneManager = GetComponent<SceneManager>();
            sceneManager.OnSceneStartLoading.AddListener(ClearScene);
        }

        private void OnDestroy()
        {
            sceneManager.OnSceneStartLoading.RemoveListener(ClearScene);
        }

        private void ClearScene()
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
                    panel.PanelActionsFragment.HideThisPanel();
                }
            }
        }
    }
}
