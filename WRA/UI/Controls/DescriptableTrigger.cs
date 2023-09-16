using UnityEngine;
using UnityEngine.EventSystems;
using WRA.General.Interfaces;
using WRA.UI.Managers;

namespace WRA.UI.Controls
{
    public abstract class DescriptableTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            // DescriptionManager.Instance.ShowDescription(GetDescription());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // DescriptionManager.Instance.HideDescription();
        }

        protected abstract string GetDescription();
    }
}
