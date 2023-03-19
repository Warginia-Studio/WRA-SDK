using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DynamicStatisticEnum))]
public class DynamicStatisticEnumEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var prop = property.FindPropertyRelative("id");
        var statisticsNames = CharacterProfile.Instance.statisticsNames;


        prop.intValue = EditorGUI.Popup(position, property.name, prop.intValue,
            CharacterProfile.Instance.statisticsNames.ToArray());
    }
}
