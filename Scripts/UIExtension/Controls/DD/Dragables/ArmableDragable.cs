using DependentObjects.Classes;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIExtension.Controls.DD.Dragables
{
    public class ArmableDragable : BaseDragable<ArmamentSlot, ArmableItem>
    {
        public override void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.4f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            transform.parent = draggingParrent;
            GrabOffset = transform.position - Input.mousePosition;
            grabbed = true;
            var drag = new DragData(HoldingItem, GrabOffset);
            drag.ArmamentContainer = ParrentSlotsController.HoldingContainer as Armament;
            DragDropManager.Instance.BeginDragItem(drag);
            
        }
    }
}
