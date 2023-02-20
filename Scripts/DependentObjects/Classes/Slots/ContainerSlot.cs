using DependentObjects.ScriptableObjects;
using UnityEngine;
using Utility.Math;

namespace Container
{
    public abstract class ContainerSlot<T> where T : ContainerItem
    {
        public int SlotId;
        public int Stack;
        public T Item;

        public ContainerSlot(T containerItem)
        {
            Item = containerItem;
        }
        

        public bool TryStack(T containerItem)
        {
            if (Item.Stacking)
                return false;
            if (containerItem.ID != Item.ID)
                return false;
            if (Stack - Item.MaxStack < 1)
                return false;

            Stack++;
            return true;
        }
        

    }
}
