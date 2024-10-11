using System;
using System.Collections.Generic;
using System.Linq;
using Codice.Client.BaseCommands;
using UnityEditor;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem;
using WRA.CharacterSystems.StatisticsSystem.Controlers;

namespace WRA_SDK.WRA.CharacterSystems.StatisticsSystem.Controllers.Editor
{
    [CustomEditor(typeof(DynamicStatisticsController))]
    public class DynamicStatisticsControllerEditor : UnityEditor.Editor
    {
        private StatisticsManager statisticsManager;
        private Dictionary<string, bool> activeStatistics = new Dictionary<string, bool>();
        private void OnEnable()
        {
            Init();
        }

        private void OnValidate()
        {
            Init();
        }

        private void Init()
        {
            var projectcontext = Resources.Load<GameObject>("ProjectContext");
            if (projectcontext == null)
            {
                Debug.LogError("ProjectContext not found");
                return;
            }
            
            statisticsManager = projectcontext.GetComponent<StatisticsManager>();

            foreach (var statistic in statisticsManager.StatisticInfos)
            {
                activeStatistics.Add(statistic.StatisticName, false);
            }

            activeStatistics.OrderBy(ctg => ctg.Value);
        }

        public override void OnInspectorGUI()
        {
            DisplayAllStatistics();
            if(GUILayout.Button("Update statistics"))
            {
                
            }
            base.OnInspectorGUI();
        }
        
        private void DisplayAllStatistics()
        {
            if (statisticsManager == null)
            {
                EditorGUILayout.HelpBox("ProjectContext or StatisticsInfoManager not found", MessageType.Error);
                return;
            }
            
            var statistics = statisticsManager.StatisticInfos;
            foreach (var statistic in statistics)
            {
                activeStatistics[statistic.StatisticName] = EditorGUILayout.Toggle(statistic.StatisticName, activeStatistics[statistic.StatisticName]);
            }
        }
    }
}
