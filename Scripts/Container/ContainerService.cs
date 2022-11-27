using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Container
{
    public abstract class ContainerService<T> : MonoBehaviour
    {
        [SerializeField] private Vector2Int containerSize;

        protected Container container;
        protected List<ContainerItem> items;

        private void Awake()
        {
            container = new Container(containerSize, typeof(T));
        }
        
        public virtual bool TryAddItem(ContainerItem item)
        {
            var addedItem = container.TryAddItem(item);
            if (addedItem == null)
                return false;
            
            items.Add(addedItem);
            return true;
        }

        public virtual bool TryAddItemAtPosition(ContainerItem item, Vector2Int position)
        {
            var addedItem = container.TryAddItemAtPosition(item, position);
            if(addedItem==null)
                return false;

            items.Add(addedItem);
            return true;
        }

        public virtual bool TryRemoveItem(ContainerItem item)
        {
            if (!container.TryRemoveItem(item))
                return false;

            items.Remove(item);
            return true;
        }
        
        // public virtual List<T> GetItems()
        // {
        //     return items;
        // }

        public virtual Container GetContainer()
        {
            return container;
        }
    }
}