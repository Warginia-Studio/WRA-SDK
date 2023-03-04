using UnityEditor;
using UnityEngine;

namespace Utility.CustomAttributes.CustomProperty
{
    [CustomPropertyDrawer(typeof(CustomObjectProperty<>))]
    public class CustomObjectPropertyPD : PropertyDrawer
    {
        private const float FOLDOUT_HEIGHT = 16f;
        private SerializedProperty valueProp;
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            valueProp = property.FindPropertyRelative("serializedProperty");

            return FOLDOUT_HEIGHT;
        }
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var attributes = fieldInfo.GetCustomAttributes(typeof(CustomSerializedField), true) as CustomSerializedField[];
            Color color = new Color(255, 255, 255, 0);
            if (attributes != null && attributes.Length > 0)
            {
                color= Color.yellow;
                if (attributes[0].Reguired)
                {
                    if (valueProp.objectReferenceValue == null)
                    {
                        color = new Color(1, 0, 0, 0.7f);
                    }
                    else
                    {
                        color = new Color(0, 1, 0, 0.7f);
                    }
                }
            }

            GUI.backgroundColor = color;
            EditorGUI.ObjectField(position, valueProp, label);
            EditorGUI.EndProperty();
        
        }
    }
}
