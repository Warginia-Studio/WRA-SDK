using System;
using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class BaseDropable<T1,T2> : CIHolder<T1, T2> , IDropHandler, IPointerEnterHandler, IPointerExitHandler where T1 : ContainerSlot<T2> where T2 : ContainerItem
{
    public UnityEvent OnPointerInDropable = new UnityEvent();
    public UnityEvent OnPointerOutDropable = new UnityEvent();

    protected Type holdingType;

    public abstract bool IsValid();
    
    public abstract void OnDrop(PointerEventData eventData);

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerInDropable.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerOutDropable.Invoke();
    }
}
