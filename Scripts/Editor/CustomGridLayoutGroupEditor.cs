using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Profiles;
using UIExtension;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomGridLayoutGroup))]
public class CustomGridLayoutGroupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (DragDropProfile.Instance != null)
        {
            EditorGUILayout.HelpBox($"If you want to change CellSize you need to do it in: {DragDropProfile.Instance.name}", MessageType.Info);
            EditorGUILayout.HelpBox($"For now i was too lazly to make correct custom editor so you can't edit other options if DDP exist.", MessageType.Info);
        }
        else
        {
            base.OnInspectorGUI();
        }

        
    }
}
