using System;
using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropableArmable : BaseDropable<ArmamentSlot, ArmableItem>
{
    public int SlotID = -1;
    private void Awake()
    {
        holdingType = typeof(ArmableItem);
    }

    public void InitID(int id)
    {
        SlotID = id;
        name = "ArmableDropable_ID_" +id;
    }

    public override bool IsValid()
    {
        return SlotID > -1;
    }

    public override void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag);
        Debug.Log(eventData.pointerDrag.name);
    }
}
