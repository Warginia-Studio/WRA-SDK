using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class ArmamentSlot : ContainerSlot<ArmableItem>
{
    public int SlotId => slotId;
    
    protected int slotId = -1;
    public ArmamentSlot(ArmableItem containerItem, int id) : base(containerItem)
    {
        slotId = id;
    }
}
