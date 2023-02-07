using UnityEngine.EventSystems;

namespace WRACore.UIExtension.Controls.Buttons
{
    public class ButtonToggle : ButtonBase, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            isActive = !isActive;
            OnStatusChanged.Invoke(isActive);
        }
    }
}
