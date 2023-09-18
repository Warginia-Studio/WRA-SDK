using UnityEngine;
using UnityEngine.EventSystems;
using WRA.CharacterSystems.InventorySystem;
using WRA.CharacterSystems.InventorySystem.Slots;
using WRA.UI.Managers;

namespace WRA.UI.Controls.DD.Dropables
{
    public class DropableArmable : BaseDropable<ArmamentSlot, ArmableItem>
    {
        public int SlotID = -1;
        protected new RectTransform rectTransform;
        protected override void Awake()
        {
            holdingType = typeof(ArmableItem);
            rectTransform = GetComponent<RectTransform>();
        }

        public void InitID(int id)
        {
            SlotID = id;
            name = "ArmableDropable_ID_" +id;
        }

        public override bool IsValid()
        {
            return SlotID > -1;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            var dragging = DragDropManager.Instance.Dragging;
            var slotStatusManager = ParrentSlotsController.SlotStatusManager;
            var globalPosition = transform.position;

            // Wrong item
            var draggingData = DragDropManager.Instance.Dragging;
            var containerItem = draggingData.ContainerItem as ArmableItem;
            if (containerItem == null)
            {
                return;
            }

            // Outside inventory or in other item
            if (!ParrentSlotsController.HoldingContainer.IsPossibleToAddItemAtSlot(draggingData.ContainerItem as ArmableItem, SlotID))
            {
                return;
            }

            // Moved item
            var container = ParrentSlotsController.HoldingContainer;
            if (container == dragging.ArmamentContainer)
            {
                container.TryMoveItem(dragging.ContainerItem as ArmableItem, SlotID);
                Debug.Log("Move item");
                return;
            }

            // If in another then remove item
            if (ParrentSlotsController.HoldingContainer.TryAddItemAtSlot(draggingData.ContainerItem as ArmableItem, SlotID))
            {
                draggingData.RemoveItemFromPreviousContainer();
            }
            
            
        }

        public override void UpdateStatus(bool enter)
        {
            var slotStatusManager = ParrentSlotsController.SlotStatusManager;
            var globalPosition = transform.position;
            
            if (!DragDropManager.Instance.IsDragging)
            {
                if (enter)
                {
                    slotStatusManager.SetStatus(globalPosition, DragDropProfile.Instance.CellSize, DragDropProfile.Status.selected);
                    return;
                }
                slotStatusManager.SetStatus(Vector3.zero, Vector2.zero, DragDropProfile.Status.empty);
                return;
            }
            
            // Wrong type
            var draggingData = DragDropManager.Instance.Dragging;
            var containerItem = draggingData.ContainerItem as ArmableItem;
            if (containerItem == null)
            {
                slotStatusManager.SetStatus(globalPosition, rectTransform.sizeDelta, DragDropProfile.Status.wrongType);
                return;
            }
            
            // In the same container
            var container = ParrentSlotsController.HoldingContainer;
            if (container == draggingData.ArmamentContainer)
            {
                // Is ok
                if(container.IsPossibleToMoveItem(draggingData.ContainerItem as ArmableItem, SlotID))
                    slotStatusManager.SetStatus(globalPosition, rectTransform.sizeDelta, DragDropProfile.Status.possible);
                // Is out of container
                else
                    slotStatusManager.SetStatus(globalPosition, rectTransform.sizeDelta, DragDropProfile.Status.busy);
                return;
            }

            // Other container
            // is outside of container
            if (!ParrentSlotsController.HoldingContainer.IsPossibleToAddItemAtSlot(draggingData.ContainerItem as ArmableItem, SlotID))
            {
                slotStatusManager.SetStatus(globalPosition, rectTransform.sizeDelta, DragDropProfile.Status.busy);
                return;
            }
            // Is ok
            slotStatusManager.SetStatus(globalPosition, rectTransform.sizeDelta, DragDropProfile.Status.possible);
        }

        public override bool IsCorrect()
        {
            var dragging = DragDropManager.Instance.Dragging;
            if (dragging == null)
                return false;
            return dragging.GetType() != typeof(ArmableItem);
        }
    }
}
