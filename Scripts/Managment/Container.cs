using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using UnityEngine;
using UnityEngine.Events;

namespace Managment
{
    public abstract class Container<TSlot, TItem> : MonoBehaviour where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
    {
        public Vector2Int OutsideInfo { get; protected set; }
        public UnityEvent OnContainerChanged = new UnityEvent();
        public abstract bool TryAddItem(TItem containerItem);
        
        public abstract bool TryAddItemAtSlot(TItem containerItem, int slotId);
        public abstract bool TryMoveItem(TItem containerItem, int slotId);
        
        public abstract bool IsPossibleToAddItemAtSlot(TItem containerItem, int slotId);
        public abstract bool IsPossibleToMoveItem(TItem containerItem, int slotId);
        public abstract bool TryRemoveItem(TItem containerItem);
        
        
        public abstract TItem[] GetItems();

        public abstract TSlot[] GetSlots();
        
        protected abstract bool CheckSlot(TItem item, int slotId);

    }
}
