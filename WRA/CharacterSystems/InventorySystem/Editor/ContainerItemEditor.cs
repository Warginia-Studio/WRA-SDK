#if UNITY_EDITOR

using UnityEditor;

namespace WRA.CharacterSystems.InventorySystem.Editor
{
    [CustomEditor(typeof(ContainerItem))]
    public class ContainerItemEditor : UnityEditor.Editor
    {
        private SerializedProperty icon;

        private void OnEnable()
        {
            icon = serializedObject.FindProperty("Icon");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            // serializedObject.Update();
            //
            //
            // ContainerItem containerItem = (ContainerItem)target;
            //
            // containerItem.ID = EditorGUILayout.IntField("Item ID: ", containerItem.ID);
            // containerItem.Size = EditorGUILayout.Vector2IntField("Size: ", containerItem.Size);
            // EditorGUILayout.PropertyField(icon);
            //
            // containerItem.Stacking = EditorGUILayout.Toggle("Stacking: ", containerItem.Stacking);
            // if (containerItem.Stacking)
            // {
            //     containerItem.MaxStack = EditorGUILayout.IntField("Max on stack: ", containerItem.MaxStack);
            // }
            //
            // serializedObject.ApplyModifiedProperties();
            // EditorUtility.SetDirty(target);
        }
    }
}


#endif