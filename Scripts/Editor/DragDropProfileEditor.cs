using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DragDropProfile))]
public class DragDropProfileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.HelpBox( "If you changed values from HEADER=Statuses, press update button.", MessageType.Warning);
        if (GUILayout.Button("Update colors"))
        {
            ((DragDropProfile)target).UpdateColors();
        }
    }
}
