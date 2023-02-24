using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventorySlotsController))]
public class InventorySlotsControllerEditor : BaseSlotsControllerEditor<InventorySlot, Item>
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
