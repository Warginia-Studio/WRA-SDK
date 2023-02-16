using UnityEngine.EventSystems;

namespace UIExtension.Controls.Buttons
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
