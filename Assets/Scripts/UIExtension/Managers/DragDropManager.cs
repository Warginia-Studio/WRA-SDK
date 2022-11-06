using Patterns;
using UIExtension.UI;

namespace UIExtension.Managers
{
    public class DragDropManager : MonoBehaviourSingletonAutoCreate<DragDropManager>
    {
        public Dragable DraggingItem => draggingItem;
        public bool Dragging => dragging;

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
