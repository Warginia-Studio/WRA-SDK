using System;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIExtension.Controls.Dragables.Dropables
{
    public class DropableItem : BaseDropable<InventorySlot, Item>
    {
        [SerializeField] private Vector2Int position;
        [SerializeField] private int id;

        public void InitId(Vector2Int position, int id)
        {
            gameObject.name = "InventoryDropable_" + id;
            this.position = position;
            this.id = id;
        }

        public override bool IsValid()
        {
            return false;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            var dragging = DragDropManager.Instance.Dragging;
            var slotStatusManager = ParrentSlotsController.SlotStatusManager;
            var globalPosition = transform.position;
            // Wrong item
            var draggingData = DragDropManager.Instance.Dragging;
            var containerItem = draggingData.ContainerItem as Item;
            
            if (containerItem == null)
            {
                return;
            }

            // Outside inventory or in other item
            if (!ParrentSlotsController.HoldingContainer.IsPossibleToAddItemAtSlot(draggingData.ContainerItem as Item, id))
            {
                return;
            }

            // Moved item
            var container = ParrentSlotsController.HoldingContainer;
            if (container == dragging.InventoryContainer)
            {
                container.TryMoveItem(dragging.ContainerItem as Item, id);
                Debug.Log("Move item");
                return;
            }

            // If in another then remove item
            if (ParrentSlotsController.HoldingContainer.TryAddItemAtSlot(draggingData.ContainerItem as Item, id))
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
            var containerItem = draggingData.ContainerItem as Item;
            if (containerItem == null)
            {
                slotStatusManager.SetStatus(globalPosition, draggingData.ContainerItem.Size*DragDropProfile.Instance.CellSize, DragDropProfile.Status.wrongType);
                return;
            }
            
            // In the same container
            var container = ParrentSlotsController.HoldingContainer;
            if (container == draggingData.InventoryContainer)
            {
                // Is ok
                if(container.IsPossibleToMoveItem(draggingData.ContainerItem as Item, id))
                    slotStatusManager.SetStatus(globalPosition, draggingData.ContainerItem.Size*DragDropProfile.Instance.CellSize, DragDropProfile.Status.possible);
                // Is out of container
                else
                    slotStatusManager.SetStatus(globalPosition, (draggingData.ContainerItem.Size -container.OutsideInfo)*DragDropProfile.Instance.CellSize, DragDropProfile.Status.busy);
                return;
            }

            // Other container
            // is outside of container
            if (!ParrentSlotsController.HoldingContainer.IsPossibleToAddItemAtSlot(draggingData.ContainerItem as Item, id))
            {
                slotStatusManager.SetStatus(globalPosition, (draggingData.ContainerItem.Size -container.OutsideInfo)*DragDropProfile.Instance.CellSize, DragDropProfile.Status.busy);
                return;
            }
            // Is ok
            slotStatusManager.SetStatus(globalPosition, draggingData.ContainerItem.Size*DragDropProfile.Instance.CellSize, DragDropProfile.Status.possible);
        }

        public override bool IsCorrect()
        {
            var dragging = DragDropManager.Instance.Dragging;
            if (dragging == null)
                return false;
            return dragging.GetType() != typeof(Item);
        }
    }
}
