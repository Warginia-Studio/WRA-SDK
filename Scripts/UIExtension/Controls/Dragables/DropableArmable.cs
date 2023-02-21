using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropableArmable : BaseDropable<ArmamentSlot, ArmableItem>
{

    public override void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
