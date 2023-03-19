using System.Collections;
using System.Collections.Generic;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.DD.Controllers;
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
