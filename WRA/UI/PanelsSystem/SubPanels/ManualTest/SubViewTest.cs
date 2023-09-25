using UnityEngine;

namespace WRA.UI.PanelsSystem.SubPanels.ManualTest
{
    public class SubViewTest : MonoBehaviour
    {
        private void Awake()
        {
            PanelManager.Instance.OpenPanel<SubViewsPanelBase>();
        }
    }
}
