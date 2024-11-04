#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace WRA.Utility.SmartObjects.Editor
{
    [CustomPropertyDrawer(typeof(SmartVariable<>), true)]
    public class SmartVariableProperty : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position , label , property);
            // EditorGUI.PropertyField(position , property.FindPropertyRelative("xd") , label);
            EditorGUI.PropertyField(position , property.FindPropertyRelative("value") , label);
            EditorGUI.EndProperty();
        }
    }
}

#endif