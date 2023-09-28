using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WRA.PlayerSystems.LanguageSystem;
using WRA.UI.PanelsSystem;

namespace WRA.General.SceneManagment
{
    public class ProgressPanel : PanelBase
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private TextTranslator sceneIsReadyText;
        [SerializeField] private KeyCode continueKey;

        private void Awake()
        {
            sceneIsReadyText.SetTextsToFormat(continueKey.ToString());
        }

        private void Update()
        {
            if (progressBar != null)
            {
                progressBar.fillAmount = CustomSceneManager.PercentOfLoad;
            }

            if (progressText != null)
            {
                progressText.text = CustomSceneManager.PercentOfLoad.ToString("P");
            }

            sceneIsReadyText.gameObject.SetActive(CustomSceneManager.SceneIsReady);
            if (CustomSceneManager.SceneIsReady && Input.GetKeyDown(continueKey))
            {
                CustomSceneManager.SetActiveNextScene();
            }
        }
        
        public override void Open(object data)
        {
            
        }

        public override void Close(object data)
        {
            
        }

        public override void OnShow(object data)
        {
            
        }

        public override void OnHide(object data)
        {
            
        }

        public void SetActiveNextScene()
        {
            CustomSceneManager.SetActiveNextScene();
        }
    }
}
