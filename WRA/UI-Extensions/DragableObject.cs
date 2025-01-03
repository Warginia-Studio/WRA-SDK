using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace WRA.UI_Extensions
{
    public class DragableObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public UnityEvent<PointerEventData> OnBeginDragEvent, OnEndDragEvent, OnDragEvent;

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDragEvent.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent.Invoke(eventData);
            transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }
}
