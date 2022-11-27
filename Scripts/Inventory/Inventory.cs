using System;
using System.Collections.Generic;
using Container;
using UnityEngine;

namespace Inventory
{
    public class Inventory : ContainerService<Item>
    {
        // [SerializeField] private Vector2Int containerSize;
        
        // public override bool TryAddItem(Item item)
        // {
        //     if (!container.TryAddItem(item))
        //         return false;
        //
        //     items.Add(item);
        //     return true;
        // }
        //
        // public override bool TryRemoveItem(Item item)
        // {
        //     if (!container.TryRemoveItem(item))
        //         return false;
        //
        //     items.Remove(item);
        //     return true;
        // }

        // public override List<Item> GetItems()
        // {
        //     return items;
        // }
        
        // public override Container<Item> GetContainer()
        // {
        //     return container;
        // }

    }
}
