using System;
using Container;
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

            if (IsTheSameContainer() && container.IsPossibleToMoveItem(dragging.ContainerItem,
                    SlotPosition - DragDropManager.Instance.Dragging.InventoryOffset)) 
            {
                SetStatus(DragDropProfile.Status.possible);
                return;
            }

            if (container.IsPossibleToAddItemAtPosition(dragging.ContainerItem,
                    SlotPosition - DragDropManager.Instance.Dragging.InventoryOffset)) 
            {
                SetStatus(DragDropProfile.Status.possible);
                return;
            }
            
            SetStatus(DragDropProfile.Status.notPossible);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetStatus(DragDropProfile.Status.empty);
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
                container.TryMoveItem(dragging.ContainerItem, slotPosition);
                return;
            }

            container.TryAddItemAtPosition(dragging.ContainerItem, slotPosition);
        }
        
        public void SetStatus(DragDropProfile.Status status, string customStatusName = "")
        {
            // if (DragDropManager.Instance == null)
            //     return;
            if (DragDropManager.Instance.DragDropProfile == null)
                return;

            StatusManager.Instance.SetStatus(status, customStatusName,
                slotPosition - DragDropManager.Instance.Dragging.InventoryOffset,
                DragDropManager.Instance.Dragging.ContainerItem.Size);
            // DropableStatus.SetStatus(status, customStatusName);
        }

        private bool IsTheSameContainer()
        {
            if (DragDropManager.Instance.Dragging.Container == Container)
            {
                return true;
            }
            return false;
        }

        private void OnStatusChanged(DragDropProfile.Status status, string customStatus, Vector2Int startPos, Vector2Int endPos)
        {
            if (BoxMath.InBox(startPos, endPos, slotPosition))
            {
                DropableStatus.SetStatus(status, customStatus);
            }
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
