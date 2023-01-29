using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UIExtension.UI.Buttons
{
    public class ButtonTrigger : ButtonBase, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (isActive)
                return;
            isActive = true;
            Onclick.Invoke();
            OnStatusChanged.Invoke(isActive);
        }

        public void ResetTrigger()
        {
            OnStatusChanged.Invoke(isActive);
        }

        public override void ChangedStatus(bool active)
        {
            throw new System.NotImplementedException();
        }
    }
}
