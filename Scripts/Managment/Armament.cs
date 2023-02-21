using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.Enums;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class Armament : Container.Container<ArmamentSlot, ArmableItem>
{
    [SerializeField] private List<ArmamentCategory> armamentBindSlots;

    private List<ArmamentSlot> armamentSlots; 

    public override bool TryAddItem(ContainerItem containerItem)
    {
        throw new System.NotImplementedException();
    }


    public override bool TryAddItemAtSlot(ContainerItem containerItem, int position)
    {
        throw new System.NotImplementedException();
    }

    public override bool TryMoveItem(ContainerItem containerItem, int slotId)
    {
        throw new System.NotImplementedException();
    }


    public override bool IsPossibleToAddItemAtSlot(ContainerItem containerItem, int slotId)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsPossibleToMoveItem(ContainerItem containerItem, int slotId)
    {
        throw new System.NotImplementedException();
    }


    public override bool TryRemoveItem(ContainerItem containerItem)
    {
        throw new System.NotImplementedException();
    }

    public override ContainerItem[] GetItems()
    {
        throw new System.NotImplementedException();
    }

    public override ArmamentSlot[] GetSlots()
    {
        throw new System.NotImplementedException();
    }

    protected override bool CheckSlot(ContainerItem item, int slotId)
    {
        throw new System.NotImplementedException();
    }
}
