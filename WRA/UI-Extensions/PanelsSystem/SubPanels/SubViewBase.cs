using UnityEngine;

namespace WRA.UI.PanelsSystem.SubPanels
{
    public abstract class SubViewBase : MonoBehaviour
    {
        public abstract void OnShow(object data);

        public abstract void OnHide();
    }
}
