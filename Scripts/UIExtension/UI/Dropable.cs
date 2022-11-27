using System;
using Container;
using UIExtension.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIExtension.UI
{
    public abstract class Dropable : ContainerHolder, IPointerEnterHandler, IPointerExitHandler, IDropHandler
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

        public abstract void OnPointerEnter(PointerEventData eventData);
    
        public abstract void OnPointerExit(PointerEventData eventData);
    
        public abstract void OnDrop(PointerEventData eventData);

        protected abstract bool IsPossibleToDrop();

        protected virtual void SetStatus(DragDropProfile.Status status, string customStatusName = "")
        {
            if (DragDropManager.Instance.DragDropProfile == null)
                return;
            dropableStatus.color = DragDropManager.Instance.DragDropProfile.GetFinalColorOfDropStatus(status, customStatusName);
        }
    }
}
