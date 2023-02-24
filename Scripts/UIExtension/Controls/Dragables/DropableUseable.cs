using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropableUseable : BaseDropable<ContainerSlot<ContainerItem>,ContainerItem>
{
    public override bool IsValid()
    {
        return true;
    }

    public override void OnDrop(PointerEventData eventData)
    {
        
    }

    public void InitId()
    {
        
    }
}
