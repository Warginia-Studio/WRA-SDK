using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.InventorySystem;
using WRA.General.Patterns;

namespace WRA.UI.Managers
{
    public class DragDropManager : MonoBehaviourSingletonAutoLoad<DragDropManager>
    {
    public UnityEvent<bool> OnDragChanged = new UnityEvent<bool>();
    public DragData Dragging => dragging;
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

    private DragData dragging;
    private bool isDragging;

    public void BeginDragItem(DragData dragData)
    {
        dragging = dragData;
        isDragging = true;
        OnDragChanged.Invoke(isDragging);
    }

    public void EndDragItem()
    {
        dragging = null;
        isDragging = false;
        OnDragChanged.Invoke(isDragging);
    }

    protected override void OnLoad()
    {
        throw new System.NotImplementedException();
    }
    }
}
