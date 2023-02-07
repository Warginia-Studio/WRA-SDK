using UnityEngine;
using UnityEngine.EventSystems;
using WRACore.UIExtension.Managers;

namespace WRACore.UIExtension.Popups
{
    public abstract class Descriptable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            DescriptionManager.Instance.ShowDescription(GetDescription());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DescriptionManager.Instance.HideDescription();
        }

        protected abstract string GetDescription();
    }
}
