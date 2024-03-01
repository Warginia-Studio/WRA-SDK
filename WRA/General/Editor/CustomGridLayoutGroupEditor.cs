#if UNITY_EDITOR

using UnityEditor;
using WRA.CharacterSystems.InventorySystem;
using WRA.UI;

namespace WRA.General.Editor
{
    [CustomEditor(typeof(CustomGridLayoutGroup))]
    public class CustomGridLayoutGroupEditor : UnityEditor.Editor
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
}

#endif