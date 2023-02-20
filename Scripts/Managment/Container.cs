using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Container
{
    public abstract class Container : MonoBehaviour
    {
        public UnityEvent OnContainerChanged = new UnityEvent();
        public abstract bool TryAddItem(ContainerItem containerItem);
        
        public abstract bool TryAddItemAtPosition(ContainerItem containerItem, Vector2Int position);
        public abstract bool TryAddItemAtSlot(ContainerItem containerItem, int position);
         
        public abstract bool TryMoveItem(ContainerItem containerItem, Vector2Int position);
        
        public abstract bool IsPossibleToAddItemAtPosition(ContainerItem containerItem, Vector2Int position);
        public abstract bool IsPossibleToAddItemAtSlot(ContainerItem containerItem, int slotId);
        
        public abstract bool IsPossibleToMoveItem(ContainerItem containerItem, Vector2Int position);
        
        public abstract bool TryRemoveItem(ContainerItem containerItem);
        
        public abstract ContainerItem[] GetItems();

        public abstract T[] GetSlots<T, G>() where T : ContainerSlot<G> where G : ContainerItem;

        // protected abstract bool IsOutsideOfInventory(ContainerItem item, Vector2Int position);
        
        // protected abstract Vector2Int FindEmptyPlace(ContainerItem item);

        protected abstract bool CheckSlot(ContainerItem item, Vector2Int position);

    }
}
