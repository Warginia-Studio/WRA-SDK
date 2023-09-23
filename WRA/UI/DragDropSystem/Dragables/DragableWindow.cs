using UnityEngine;
using UnityEngine.EventSystems;

namespace WRA.UI.DragDropSystem.Dragables
{
    public class DragableWindow : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Vector3 offset;
        public void OnBeginDrag(PointerEventData eventData)
        {
            offset = transform.position - Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition + offset;
        }
    }
}
