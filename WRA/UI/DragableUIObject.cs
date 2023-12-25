using UnityEngine;
using UnityEngine.EventSystems;

namespace WRA.UI
{
    public class DragableUIObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        public void OnBeginDrag(PointerEventData eventData)
        {
        
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }
}
