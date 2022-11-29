using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIExtension.UI
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
