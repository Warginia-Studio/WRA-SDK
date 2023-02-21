using System.Collections;
using System.Collections.Generic;using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CIHolder<T1, T2> : MonoBehaviour where T1 : ContainerSlot<T2> where T2 : ContainerItem
{
    public T1 HoldingItem { get; protected set; }
    public T2 ParrentContainer { get; protected set; }

    public virtual void SetInfo(T2 container, T1 item = null)
    {
        HoldingItem = item;
        ParrentContainer = container;
    }
}
