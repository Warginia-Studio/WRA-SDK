using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Container
{
    public abstract class Container<TSlot, TItem> : MonoBehaviour where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
    {
        public UnityEvent OnContainerChanged = new UnityEvent();
        public abstract bool TryAddItem(ContainerItem containerItem);
        
        public abstract bool TryAddItemAtSlot(ContainerItem containerItem, int slotId);
        public abstract bool TryMoveItem(ContainerItem containerItem, int slotId);
        
        public abstract bool IsPossibleToAddItemAtSlot(ContainerItem containerItem, int slotId);
        public abstract bool IsPossibleToMoveItem(ContainerItem containerItem, int slotId);
        public abstract bool TryRemoveItem(ContainerItem containerItem);
        
        public abstract ContainerItem[] GetItems();

        public abstract TSlot[] GetSlots();
        
        protected abstract bool CheckSlot(ContainerItem item, int slotId);

    }
}
