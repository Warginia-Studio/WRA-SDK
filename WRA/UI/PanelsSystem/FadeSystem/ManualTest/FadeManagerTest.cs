using UnityEngine;

namespace WRA.UI.PanelsSystem.FadeSystem.ManualTest
{
    public class FadeManagerTest : MonoBehaviour
    {
        private FadeManager fadeManager;
        private void Awake()
        {
            fadeManager = PanelManager.Instance.OpenPanel<FadeManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                fadeManager.FadeIn();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                fadeManager.FadeOut();
            }
        }
    }
}
