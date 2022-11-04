using Patterns;
using UIExtension.UI;

namespace UIExtension.Managers
{
    public class DragDropManager : MonoBehaviourSingletonAutoCreate<DragDropManager>
    {
        public Dragable DraggingItem => draggingItem;
        public bool Dragging { get; private set; }

        private Dragable draggingItem;
        public void BeginDragItem(Dragable dragable)
        {
            Dragging = true;
            draggingItem = dragable;
        }

        public void EndDragItem()
        {
            Dragging = false;
            draggingItem = null;
        }
    }
}
