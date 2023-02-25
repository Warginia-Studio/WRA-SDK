using System;
using System.Collections;
using System.Collections.Generic;using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CIHolder<TSlot, TItem> : MonoBehaviour where TSlot : ContainerSlot<TItem> where TItem : ContainerItem
{
    public Container<TSlot, TItem> ParrentContainer  { get; protected set; }
    public TItem HoldingItem  { get; protected set; }
    
    public Type HoldingType { get; protected set; }

    public virtual void SetInfo(Container<TSlot, TItem>  container, TItem item = null)
    {
        HoldingItem = item;
        ParrentContainer = container;
        HoldingType = item?.GetType();
    }
}
