#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Editor
{
    [CustomPropertyDrawer(typeof(DynamicStatisticEnum))]
    public class DynamicStatisticEnumEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // var prop = property.FindPropertyRelative("id");
            // var statisticsNames = StatisticsProfile.Instance.statisticsNames;


            // prop.intValue = EditorGUI.Popup(position, property.name, prop.intValue,
                // StatisticsProfile.Instance.statisticsNames.ToArray());
        }
    }
}

#endif