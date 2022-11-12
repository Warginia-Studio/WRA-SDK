using Patterns;
using UIExtension.UI;
using UnityEngine;

namespace UIExtension.Managers
{
    public class DragDropManager : MonoBehaviourSingletonAutoCreate<DragDropManager>
    {
        public Dragable DraggingItem => draggingItem;
        public bool Dragging => dragging;

        public static DragDropProfile DragDropProfile
        {
            get
            {
                if (dragDropProfile == null)
                {
                    dragDropProfile = Resources.Load<DragDropProfile>("");
                }

                return dragDropProfile;
            }
        }

        [SerializeField] private static DragDropProfile dragDropProfile;
        
        // [SerializeField] private 

        private Dragable draggingItem;
        private bool dragging;
        public void BeginDragItem(Dragable dragable)
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
