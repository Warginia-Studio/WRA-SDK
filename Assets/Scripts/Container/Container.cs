using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container
{
    private List<ContainerSlot> items = new List<ContainerSlot>();
    private Vector2Int containerSize;

    public Container(Vector2Int containerSize)
    {
        
    }

    public bool TryAddItem(ContainerItem containerItem)
    {
        var item = ScriptableObject.Instantiate(containerItem);
        return false;
    }

    public bool TryRemoveItem(ContainerItem containerItem)
    {

        return false;
    }
    
 
}
