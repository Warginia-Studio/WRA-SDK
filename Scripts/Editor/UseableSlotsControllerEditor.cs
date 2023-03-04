using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.Dragables.Controllers;
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
