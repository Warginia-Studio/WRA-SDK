using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DependentObjects.ScriptableObjects;
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
