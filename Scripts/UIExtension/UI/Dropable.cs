using System;
using Container;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIExtension.UI
{
    public sealed class Dropable : ContainerHolder, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        protected Image DropableStatus
        {
            get
            {
                if (dropableStatus == null)
                {
                    dropableStatus = GetComponent<Image>();
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
    
        private Image dropableStatus;

        public void OnPointerEnter(PointerEventData eventData)
        {
            var dragging = DragDropManager.Instance.Dragging;
            if (dragging.DraggingType == container.HoldingType)
            {
                SetStatus(DragDropProfile.Status.wrongType);
                return;
            }

            if (IsTheSameContainer() && container.IsPossibleToMoveItem(dragging.DraggingGameObjcet.ContainerItem, SlotPosition))
            {
                SetStatus(DragDropProfile.Status.possible);
                return;
            }

            if (container.IsPossibleToAddItemAtPosition(dragging.DraggingGameObjcet.ContainerItem, SlotPosition))
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
            if (dragging.DraggingGameObjcet.ContainerItem.GetType() == container.GetType())
            {
                SetStatus(DragDropProfile.Status.wrongType);
                return;
            }

            if (IsTheSameContainer())
            {
                container.TryMoveItem(dragging.DraggingGameObjcet.ContainerItem, slotPosition);
                SetStatus(DragDropProfile.Status.possible);
                return;
            }

            container.TryAddItemAtPosition(dragging.DraggingGameObjcet.ContainerItem, slotPosition);
        }
        
        protected void SetStatus(DragDropProfile.Status status, string customStatusName = "")
        {
            // if (DragDropManager.Instance == null)
            //     return;
            if (DragDropManager.Instance.DragDropProfile == null)
                return;
            dropableStatus.color = DragDropManager.Instance.DragDropProfile.GetFinalColorOfDropStatus(status, customStatusName);
        }

        private bool IsTheSameContainer()
        {
            if (DragDropManager.Instance.Dragging.DraggingGameObjcet.Container == Container)
            {
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            SetStatus(DragDropProfile.Status.empty);   
        }
    }
}
