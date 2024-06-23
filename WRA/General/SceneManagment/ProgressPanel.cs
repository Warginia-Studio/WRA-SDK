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
        
        [Inject] private ILoadingStatus loadingStatus;

        private void Awake()
        {
            sceneIsReadyText.SetTextsToFormat(continueKey.ToString());
        }

        private void Update()
        {
            if(loadingStatus == null)
                return;
            
            if (progressBar != null)
            {
                progressBar.fillAmount = loadingStatus.GetProgress();
            }

            if (progressText != null)
            {
                progressText.text = loadingStatus.GetProgress().ToString("P");
            }

            sceneIsReadyText.gameObject.SetActive(loadingStatus.IsReady());
            if (loadingStatus.IsReady() && Input.GetKeyDown(continueKey))
            {
                loadingStatus.StartScene();
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
