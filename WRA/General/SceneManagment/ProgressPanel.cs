using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WRA.PlayerSystems.LanguageSystem;
using WRA.UI.PanelsSystem;
using Zenject;

namespace WRA.General.SceneManagment
{
    public class ProgressPanel : PanelBase
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private TextTranslator sceneIsReadyText;
        [SerializeField] private KeyCode continueKey;
        
        [Inject] private ILoadingScene loadingScene;

        private void Awake()
        {
            sceneIsReadyText.SetTextsToFormat(continueKey.ToString());
        }

        private void Update()
        {
            if(loadingScene == null)
                return;
            
            if (progressBar != null)
            {
                progressBar.fillAmount = loadingScene.GetProgress();
            }

            if (progressText != null)
            {
                progressText.text = loadingScene.GetProgress().ToString("P");
            }

            sceneIsReadyText.gameObject.SetActive(loadingScene.IsReady());
            if (loadingScene.IsReady() && Input.GetKeyDown(continueKey))
            {
                loadingScene.StartScene();
            }
        }

        // public override void OnOpen()
        // {
        //     var data = (PanelDataBase)base.data;
        //     var progressData = (ILoadingStatus) data.Data;
        //     loadingStatus = progressData;
        // }
    }
}
