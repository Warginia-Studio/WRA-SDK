using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UIExtension.UI.Buttons
{
    public class ButtonTrigger : ButtonBase, IPointerClickHandler
    {
        public UnityEvent OnReset = new UnityEvent();
        public void OnPointerClick(PointerEventData eventData)
        {
            if (isActive)
                return;
            isActive = true;
            OnStatusChanged.Invoke(isActive);
            Onclick.Invoke();
        }

        public void ResetTrigger()
        {
            if (!isActive)
                return;
            isActive = false;
            OnStatusChanged.Invoke(isActive);
            OnReset.Invoke();
        }
    }
}
