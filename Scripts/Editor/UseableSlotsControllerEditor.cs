using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Container;
using DependentObjects.ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UseableSlotsController))]
public class UseableSlotsControllerEditor : BaseSlotsControllerEditor<ContainerSlot<ContainerItem>, ContainerItem>
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
