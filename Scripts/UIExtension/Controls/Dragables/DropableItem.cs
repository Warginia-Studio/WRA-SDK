using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropableItem : BaseDropable<InventorySlot, Item>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
