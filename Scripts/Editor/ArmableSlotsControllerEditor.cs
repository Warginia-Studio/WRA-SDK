using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Managment;
using UIExtension.Controls.DD.Controllers;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ArmableSlotsController))]
public class ArmableSlotsControllerEditor : BaseSlotsControllerEditor<ArmamentSlot, ArmableItem>
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
