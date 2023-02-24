using System.Collections;
using System.Collections.Generic;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEngine;

public class InventorySlotsController : BaseSlotsController<InventorySlot, Item>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Open(Container<InventorySlot, Item> container)
    {
        HoldingContainer = container;
    }

    public override void InitSlots()
    {
        var newDropables = transform.GetComponentsInChildren<DropableItem>();
        if (Dropables.Length != newDropables.Length)
            Dropables = newDropables;
        
        for (int i = 0; i < Dropables.Length; i++)
        {
            (Dropables[i] as DropableItem).InitId();
        }
    }
    
}
