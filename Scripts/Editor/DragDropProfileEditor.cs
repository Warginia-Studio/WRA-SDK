using DependentObjects.ScriptableObjects.Profiles;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(DragDropProfile))]
    public class DragDropProfileEditor : UnityEditor.Editor
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
}
