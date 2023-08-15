using UnityEngine;
using UnityEngine.EventSystems;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Managment;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.General.Classes;
using WRA.UI.Managers;

namespace WRA.UI.Controls.DD.Dragables
{
    public class ItemDragable : BaseDragable<InventorySlot, Item>
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
            drag.InventoryContainer = ParrentSlotsController.HoldingContainer as Inventory;
            DragDropManager.Instance.BeginDragItem(drag);
            
        }
    }
}
