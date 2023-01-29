using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UIExtension.UI.Buttons
{
    public class ButtonToggle : ButtonBase, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            isActive = !isActive;
            OnStatusChanged.Invoke(isActive);
        }

        public override void ChangedStatus(bool active)
        {
            throw new System.NotImplementedException();
        }
    }
}
