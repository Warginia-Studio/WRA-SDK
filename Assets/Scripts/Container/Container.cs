using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Container
{
    public class Container
    {
        public UnityEvent OnContainerChanged = new UnityEvent();
    
        private List<ContainerSlot> slots = new List<ContainerSlot>();
        private Vector2Int containerSize;

        public Container(Vector2Int containerSize)
        {
            this.containerSize = containerSize;
        }

        public ContainerItem TryAddItem(ContainerItem containerItem)
        {
        
            var slot = FindEmptyPlace(containerItem);

            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].TryStack(containerItem))
                {
                    OnContainerChanged.Invoke();
                    return slots[i].Item;
                }
            }
        
            if (slot == -Vector2Int.one)
                return null;
        
            var item = ScriptableObject.Instantiate(containerItem);
            slots.Add(new ContainerSlot(item, slot));
        
            OnContainerChanged.Invoke();
            return item;
        }

        public bool TryRemoveItem(ContainerItem containerItem)
        {
            bool result = slots.Remove(slots.Find(ctg => ctg.Item == containerItem));

            OnContainerChanged.Invoke();
            return result;
        }

        public ContainerItem[] GetItems()
        {
            var items = this.slots.Select(ctg => ctg.Item);

            return items.ToArray();
        }

        public ContainerSlot[] GetSlots()
        {
            return slots.ToArray();
        }
    
        private bool IsOutsideOfInventory(ContainerItem item, Vector2Int position)
        {
            if (position.x < 0 || position.y < 0)
                return true;
            if (position.x + item.Size.x > containerSize.x || position.y + item.Size.y > containerSize.y)
                return true;
            return false;
        }
    
        private Vector2Int FindEmptyPlace(ContainerItem item)
        {
            for (int i = 0; i < containerSize.y; i++)
            {
                for (int j = 0; j < containerSize.x; j++)
                {
                    if (!IsOutsideOfInventory(item, new Vector2Int(j,i)) && !CheckSlots(item, new Vector2Int(j, i)))
                    {
                        return new Vector2Int(j, i);
                    }
                }
            }
            return -Vector2Int.one;
        }
    
        private bool CheckSlots(ContainerItem item, Vector2Int position)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].IsInside(position, item.Size))
                    return true;
            }
            return false;
        }
    }
}
