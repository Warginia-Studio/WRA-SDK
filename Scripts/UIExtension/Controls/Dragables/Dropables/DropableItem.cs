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

            if (!IsCorrect())
            {
                return;
            }

            if (!ParrentSlotsController.HoldingContainer.IsPossibleToAddItemAtSlot(dragging.ContainerItem as Item, id))
            {
                // Status background 
                return;
            }
        }

        public override void UpdateStatus(bool enter)
        {
            var slotStatusManager = ParrentSlotsController.SlotStatusManager;
            if (!DragDropManager.Instance.IsDragging)
            {
                if (enter)
                {
                    slotStatusManager.SetStatus(transform.position, DragDropProfile.Instance.CellSize, DragDropProfile.Status.selected);
                    return;
                }
                slotStatusManager.SetStatus(Vector3.zero, Vector2.zero, DragDropProfile.Status.empty);
                return;
            }

            var draggingData = DragDropManager.Instance.Dragging;
            var containerItem = draggingData.ContainerItem as Item;
            if (containerItem == null)
            {
                slotStatusManager.SetStatus(transform.position, draggingData.ContainerItem.Size*DragDropProfile.Instance.CellSize, DragDropProfile.Status.wrongType);
                return;
            }

            if (!ParrentSlotsController.HoldingContainer.IsPossibleToAddItemAtSlot(draggingData.ContainerItem as Item, id))
            {
                slotStatusManager.SetStatus(transform.position, draggingData.ContainerItem.Size*DragDropProfile.Instance.CellSize, DragDropProfile.Status.busy);
                return;
            }
            
            slotStatusManager.SetStatus(transform.position, draggingData.ContainerItem.Size*DragDropProfile.Instance.CellSize, DragDropProfile.Status.possible);
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
