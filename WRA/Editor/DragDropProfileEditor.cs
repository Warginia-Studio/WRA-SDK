using UnityEditor;
using UnityEngine;
using WRA.CharacterSystems.InventorySystem;

namespace WRA.Editor
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
