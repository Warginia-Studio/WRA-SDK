using UnityEngine;

namespace WRA.UI.PanelsSystem.CinematicSystem.ManualTest
{
    public class ManualTestCinematicCameraPanel : MonoBehaviour
    {
        private void Awake()
        {
            PanelManager.Instance.OpenPanel<CinematicCameraPanel>(new CinematicCameraData() { StartAsShow = true});
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                PanelManager.Instance.GetPanel<CinematicCameraPanel>().ShowCurtains();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                PanelManager.Instance.GetPanel<CinematicCameraPanel>().HideCurtains();
            }
        }
    }
}
