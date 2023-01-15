using System;
using Container;
using DependentObjects.ScriptableObjects;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIExtension.UI
{
    public sealed class Dropable : ContainerHolder, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        protected StatusChanger DropableStatus
        {
            get
            {
                if (dropableStatus == null)
                {
                    dropableStatus = GetComponentInChildren<StatusChanger>();
                }

                return dropableStatus;
            }
        }

        public Vector2Int SlotPosition
        {
            get => slotPosition;
            set => slotPosition = value;
        }

        private Vector2Int slotPosition;
    
        private StatusChanger dropableStatus;

        private void Awake()
        {
            GetComponent<RectTransform>().sizeDelta = DragDropProfile.Instance.CellSize;
            StatusManager.Instance.OnStatusChanged.AddListener(OnStatusChanged);
        }

        private void OnDestroy()
        {
            StatusManager.Instance.OnStatusChanged.RemoveListener(OnStatusChanged);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            var dragging = DragDropManager.Instance.Dragging;
            if (dragging == null)
            {
                SetStatus(DragDropProfile.Status.selected);
                return;
            }
            if (dragging.Container.HoldingType.GetHashCode() != container.HoldingType.GetHashCode())
            {
                SetStatus(DragDropProfile.Status.wrongType);
                return;
            }

            // Debug.Log(
            //     $"SlotPosition: {SlotPosition} , DraggingOffset: {DragDropManager.Instance.Dragging.InventoryOffset}" +
            //     $"Finall vector: {SlotPosition-DragDropManager.Instance.Dragging.InventoryOffset}");

            if (IsTheSameContainer() && container.IsPossibleToMoveItem(dragging.ContainerItem,
                    SlotPosition - DragDropManager.Instance.Dragging.InventoryOffset)) 
            {
                SetStatus(DragDropProfile.Status.possible);
                return;
            }

            if (!IsTheSameContainer() && container.IsPossibleToAddItemAtPosition(dragging.ContainerItem,
                    SlotPosition + DragDropManager.Instance.Dragging.InventoryOffset)) 
            {
                SetStatus(DragDropProfile.Status.possible);
                return;
            }
            
            SetStatus(DragDropProfile.Status.notPossible);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DropableStatus.SetStatus(DragDropProfile.Status.empty, "");
        }

        public void OnDrop(PointerEventData eventData)
        {
            var dragging = DragDropManager.Instance.Dragging;
            if (dragging.Container.HoldingType.GetHashCode() != container.HoldingType.GetHashCode())
            {
                return;
            }

            if (IsTheSameContainer())
            {
                container.TryMoveItem(dragging.ContainerItem, SlotPosition - DragDropManager.Instance.Dragging.InventoryOffset);
                return;
            }

            if (container.TryAddItemAtPosition(dragging.ContainerItem,
                    SlotPosition - DragDropManager.Instance.Dragging.InventoryOffset))
            {
                Debug.Log("Removed: " + dragging.Container.TryRemoveItem(dragging.ContainerItem));
            }
            DragDropManager.Instance.EndDragItem();
        }
        
        public void SetStatus(DragDropProfile.Status status, string customStatusName = "")
        {
            if (DragDropManager.Instance.DragDropProfile == null)
                return;
            if (DragDropManager.Instance.Dragging == null)
            {
                DropableStatus.SetStatus(DragDropProfile.Status.selected, "");
                return;
            }

            StatusManager.Instance.SetStatus(status, customStatusName, container,
                slotPosition - DragDropManager.Instance.Dragging.InventoryOffset,
                DragDropManager.Instance.Dragging.ContainerItem.Size);
        }

        private bool IsTheSameContainer()
        {
            if (DragDropManager.Instance.Dragging.Container == Container)
            {
                return true;
            }
            return false;
        }

        private void OnStatusChanged(StatusManager.OnStatusChangedInfo info)
        {
            if (info.Holder != container)
            {
                DropableStatus.SetStatus(DragDropProfile.Status.empty, "");
                return;
            }
            if (BoxMath.InBox(info.StartPos, info.EndPos, slotPosition))
            {
                DropableStatus.SetStatus(info.Status, info.CustomStatus);
            }
            else
            {
                DropableStatus.SetStatus(DragDropProfile.Status.empty, "");
            }
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
