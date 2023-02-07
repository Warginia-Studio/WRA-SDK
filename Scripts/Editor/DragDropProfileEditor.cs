using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using WRACore.DependentObjects.ScriptableObjects;

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
