using System;
using Container;
using Patterns;
using UIExtension.UI;
using UnityEngine;
using UnityEngine.Events;

namespace UIExtension.Managers
{
    public class DragDropManager : MonoBehaviourSingletonAutoLoad<DragDropManager>
    {
        public UnityEvent<bool> OnDragChanged = new UnityEvent<bool>();
        public Dragable Dragging => dragging;
        public bool IsDragging => isDragging;

        public DragDropProfile DragDropProfile
        {
            get
            {
                if (dragDropProfile == null)
                {
                    dragDropProfile = Resources.Load<DragDropProfile>("DDP_Default");
                }

                return dragDropProfile;
            }
        }

        [SerializeField] private DragDropProfile dragDropProfile;
        
        // [SerializeField] private 

        private Dragable dragging;
        private bool isDragging;

        public void BeginDragItem(Dragable draggingData)
        {
            dragging = draggingData;
            isDragging = true;
            OnDragChanged.Invoke(isDragging);
        }

        public void EndDragItem()
        {
            dragging = null;
            isDragging = false;
            OnDragChanged.Invoke(isDragging);
        }
        
        // public void BeginDragItem(Dragable<T> dragable)
        // {
        //     isDragging = true;
        //     draggingItem = dragable;
        // }
        //
        // public void EndDragItem()
        // {
        //     isDragging = false;
        //     draggingItem = null;
        // }
    }
}
