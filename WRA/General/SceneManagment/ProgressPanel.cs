using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WRA.UI.PanelsSystem;

namespace WRA.General.SceneManagment
{
    public class ProgressPanel : PanelBase
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private TextMeshProUGUI sceneIsReadText;

        private void Update()
        {
            if (progressBar != null)
            {
                progressBar.fillAmount = CustomSceneManager.PercentOfLoad;
            }

            if (progressText != null)
            {
                progressText.text = CustomSceneManager.PercentOfLoad.ToString("P");
                if (CustomSceneManager.SceneIsReady)
                {
                    progressText.text = (1f).ToString("P");
                }
            }

            sceneIsReadText.gameObject.SetActive(CustomSceneManager.SceneIsReady);
            if (CustomSceneManager.SceneIsReady && Input.GetKeyDown(KeyCode.Space))
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
