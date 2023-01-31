using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UIExtension.UI.Buttons
{
    public class ButtonTrigger : ButtonBase, IPointerClickHandler
    {
        [HideInInspector] public UnityEvent<int> OnClick = new UnityEvent<int>();
        public int ButtonId => buttonId;
        [SerializeField] private int buttonId;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick.Invoke(buttonId);
        }
        
        public void SetStatus(bool active)
        {
            isActive = active;
            OnStatusChanged.Invoke(isActive);
        }
    }
}
