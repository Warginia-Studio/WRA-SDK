using System;
using DependentObjects.ScriptableObjects;
using UIExtension.Controls.Containers;
using UIExtension.Controls.Feedback;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using Utility.Math;

namespace UIExtension.Controls.Dragables
{
    public sealed class DropableContainerItem : ContainerHolder, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        private StatusChanger DropableStatus
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

        [SerializeField] private bool useOffset = true;

        private Vector2Int slotPosition;
    
        private StatusChanger dropableStatus;

        private void Start()
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
            
            // if (dragging.GetType().IsSubclassOf(container.HoldingType) || dragging.GetType() == Container.HoldingType)
            // {
            //     SetStatus(DragDropProfile.Status.wrongType);
            //     return;
            // }

            // Debug.Log(
            //     $"SlotPosition: {SlotPosition} , DraggingOffset: {DragDropManager.Instance.Dragging.InventoryOffset}" +
            //     $"Finall vector: {SlotPosition-DragDropManager.Instance.Dragging.InventoryOffset}");

            if (IsTheSameContainer() && container.IsPossibleToMoveItem(dragging.ContainerItem,
                    SlotPosition - (useOffset ? DragDropManager.Instance.Dragging.InventoryOffset : Vector2Int.one))) 
            {
                SetStatus(DragDropProfile.Status.possible);
                return;
            }

            if (!IsTheSameContainer() && container.IsPossibleToAddItemAtPosition(dragging.ContainerItem,
                    SlotPosition + (useOffset ? DragDropManager.Instance.Dragging.InventoryOffset : Vector2Int.one))) 
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
            // if (dragging.GetType().IsSubclassOf(container.HoldingType) || dragging.GetType() == Container.HoldingType)
            // {
            //     return;
            // }

            if (IsTheSameContainer())
            {
                container.TryMoveItem(dragging.ContainerItem, SlotPosition - (useOffset ? DragDropManager.Instance.Dragging.InventoryOffset : Vector2Int.one));
                return;
            }

            if (container.TryAddItemAtPosition(dragging.ContainerItem,
                    SlotPosition - (useOffset ? DragDropManager.Instance.Dragging.InventoryOffset : Vector2Int.one)))
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
                slotPosition - (useOffset ? DragDropManager.Instance.Dragging.InventoryOffset : Vector2Int.one),
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
