using System;
using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class ArmableSlotsController : BaseSlotsController<ArmamentSlot, ArmableItem>
{
    
    private void Awake()
    {
        
    }


    public override void Open(Container<ArmamentSlot, ArmableItem> container)
    {
        HoldingContainer = container;
    }

    public override void InitSlots()
    {
        var newDropables = transform.GetComponentsInChildren<DropableArmable>();
        if (Dropables.Length != newDropables.Length)
            Dropables = newDropables;
        
        for (int i = 0; i < Dropables.Length; i++)
        {
            (Dropables[i] as DropableArmable).InitID(i);
        }
    }
}
