using System;
using System.Collections.Generic;
using System.Linq;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Container
{
    public abstract class Container : MonoBehaviour
    {
        [HideInInspector] public UnityEvent OnContainerChanged = new UnityEvent();
        public Type HoldingType => holdingType;
        public Vector2Int containerSize => new Vector2Int(xSize, ySize);
    
        [SerializeField] protected int xSize;
        [SerializeField] protected int ySize;
        
        protected List<ContainerSlot> slots = new List<ContainerSlot>();
       
        protected Type holdingType;
        

        public virtual bool TryAddItem(ContainerItem containerItem)
        {
        
            var slot = FindEmptyPlace(containerItem);

            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].TryStack(containerItem))
                {
                    OnContainerChanged.Invoke();
                    return true;
                }
            }
        
            if (slot == -Vector2Int.one)
                return false;
        
            var item = ScriptableObject.Instantiate(containerItem);
            slots.Add(new ContainerSlot(item, slot));
        
            OnContainerChanged.Invoke();
            return true;
        }

        public virtual bool TryAddItemAtPosition(ContainerItem containerItem, Vector2Int position)
        {
            if(CheckSlot(containerItem, position) || IsOutsideOfInventory(containerItem, position))
            {
                return false;
            }


            var item = Instantiate(containerItem);
            slots.Add(new ContainerSlot(item, position));

            OnContainerChanged.Invoke();
            return true;
        }

        public virtual bool TryMoveItem(ContainerItem containerItem, Vector2Int position)
        {
            if (!IsPossibleToMoveItem(containerItem, position))
            {
                return false;
            }

            slots.Find(ctg => ctg.Item == containerItem).Position = position;
            OnContainerChanged.Invoke();
            return true;
        }

        public virtual bool IsPossibleToAddItemAtPosition(ContainerItem containerItem, Vector2Int position)
        {
            if (CheckSlot(containerItem, position) || IsOutsideOfInventory(containerItem, position))
            {
                return false;
            }
            return true;
        }

        public virtual bool IsPossibleToMoveItem(ContainerItem containerItem, Vector2Int position)
        {
            if (CheckSlot(containerItem, position) || IsOutsideOfInventory(containerItem, position))
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerItem"></param>
        /// <returns></returns>

        public virtual bool TryRemoveItem(ContainerItem containerItem)
        {
            bool result = slots.Remove(slots.Find(ctg => ctg.Item == containerItem));

            OnContainerChanged.Invoke();
            return result;
        }

        public virtual ContainerItem[] GetItems()
        {
            var items = this.slots.Select(ctg => ctg.Item);

            return items.ToArray();
        }

        public virtual ContainerSlot[] GetSlots()
        {
            return slots.ToArray();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position"></param>
        /// <returns>If position is outside inventory return true, else return false</returns>
    
        protected virtual bool IsOutsideOfInventory(ContainerItem item, Vector2Int position)
        {
            if (position.x < 0 || position.y < 0)
                return true;
            if (position.x + item.Size.x > containerSize.x || position.y + item.Size.y > containerSize.y)
                return true;
            return false;
        }

        /// <summary>
        /// Finding empty place
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Return position if found free slot, return new Vector2Int(-1-1) if not found.</returns>
    
        protected virtual Vector2Int FindEmptyPlace(ContainerItem item)
        {
            for (int i = 0; i < containerSize.y; i++)
            {
                for (int j = 0; j < containerSize.x; j++)
                {
                    if (!IsOutsideOfInventory(item, new Vector2Int(j,i)) && !CheckSlot(item, new Vector2Int(j, i)))
                    {
                        return new Vector2Int(j, i);
                    }
                }
            }
            return -Vector2Int.one;
        }

        /// <summary>
        /// Checking slots by item size and position
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position"></param>
        /// <returns>Return true if slot is busy, false if empty</returns>
    
        protected virtual bool CheckSlot(ContainerItem item, Vector2Int position)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].IsInside(position, item))
                    return true;
            }
            return false;
        }
    }
}
