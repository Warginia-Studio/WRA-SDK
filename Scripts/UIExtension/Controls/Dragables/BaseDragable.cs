using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseDragable : CIHolder<ContainerSlot<ContainerItem> , ContainerItem>, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 GrabOffset { get; private set; }
    
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        // calculate grab offset
        throw new System.NotImplementedException();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        // move item
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // reset item
        throw new System.NotImplementedException();
    }
}
