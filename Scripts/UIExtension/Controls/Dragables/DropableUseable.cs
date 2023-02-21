using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropableUseable : BaseDropable<ContainerSlot<ContainerItem>,ContainerItem>
{


    public override void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
