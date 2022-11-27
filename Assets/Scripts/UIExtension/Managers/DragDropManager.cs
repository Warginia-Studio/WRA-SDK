using Patterns;
using UIExtension.UI;
using UnityEngine;

namespace UIExtension.Managers
{
    public class DragDropManager<T> : Singleton<DragDropManager<T>>
    {
        public Dragable<T> DraggingItem => draggingItem;
        public bool Dragging => dragging;

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

        private Dragable<T> draggingItem;
        private bool dragging;
        
        public void BeginDragItem(Dragable<T> dragable)
        {
            dragging = true;
            draggingItem = dragable;
        }

        public void EndDragItem()
        {
            dragging = false;
            draggingItem = null;
        }
    }
}
