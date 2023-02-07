using UnityEngine;
using UnityEngine.Events;
using WRACore.DependentObjects.ScriptableObjects;
using WRACore.Patterns;
using WRACore.UIExtension.Controls.Dragables;

namespace WRACore.UIExtension.Managers
{
    public class DragDropManager : MonoBehaviourSingletonAutoLoad<DragDropManager>
    {
        public UnityEvent<bool> OnDragChanged = new UnityEvent<bool>();
        public DragableContainerItem Dragging => dragging;
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

        private DragableContainerItem dragging;
        private bool isDragging;

        public void BeginDragItem(DragableContainerItem draggingData)
        {
            dragging = draggingData;
            isDragging = true;
            OnDragChanged.Invoke(isDragging);
        }

        public void EndDragItem()
        {
            dragging = null;
            isDragging = false;
            StatusManager.Instance.Reset();
            OnDragChanged.Invoke(isDragging);
        }
    }
}
