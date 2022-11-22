using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Container;


public class Inventory : MonoBehaviour
{
    protected Container.Container<Item> container;
    private List<Item> items = new List<Item>();

    public bool TryAddItem(Item item)
    {
        if (!container.TryAddItem(item))
            return false;

        items.Add(item);
        return true;
    }

    public bool TryRemoveItem(Item item)
    {
        if (!container.TryRemoveItem(item))
            return false;

        items.Remove(item);
        return true;
    }

    public Container.Container<Item> GetContainer()
    {
        return container;
    }

}
