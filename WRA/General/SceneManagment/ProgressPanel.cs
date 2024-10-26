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
    public class ProgressPanel : PanelFragmentBase
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
            if (loadingScene == null)
            {
                progressText.text = "Loading Scene is null";
                return;
            }

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

        public override void OnPanelDataChanged()
        {
            loadingScene = ParentPanel.GetDataAsType<PanelDataBase>().Data as ILoadingScene;
        }
    }
}
