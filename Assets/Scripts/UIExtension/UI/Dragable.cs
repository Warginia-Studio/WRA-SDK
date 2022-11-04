using UnityEngine;
using UnityEngine.EventSystems;

namespace DragDrop.UI
{
    public abstract class Dragable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.BeginDragItem(this);
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            DragDropManager.Instance.EndDragItem();
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            DescriptionManager.Instance.ShowDescription(GetDescription());
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            DescriptionManager.Instance.HideDescription();
        }

        protected abstract string GetDescription();
    }
}
