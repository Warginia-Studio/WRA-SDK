using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA_SDK.WRA.CharacterSystems.StatisticsSystem.Controllers.Editor
{
    [CustomEditor(typeof(StatisticsController))]
    public class DynamicStatisticsControllerEditor : UnityEditor.Editor
    {
        private StatisticsManager statisticsManager;
        private Dictionary<string, bool> activeStatistics = new Dictionary<string, bool>();
        private bool showStatisticsOptions = false;
        private List<DynamicStatisticValue> statistics;

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

            statisticsManager = projectcontext.GetComponentInChildren<StatisticsManager>();
            statistics = ((StatisticsController)target).GetStatistics();

            foreach (var statistic in statisticsManager.StatisticInfos)
            {
                var exist = statistics.Exists(ctg => ctg.StatisticName == statistic.StatisticName);
                activeStatistics.Add(statistic.StatisticName, exist);
            }

            activeStatistics.OrderBy(ctg => ctg.Value);
            
        }

        public override void OnInspectorGUI()
        {
            DisplayAllStatistics();

            base.OnInspectorGUI();
        }

        private void DisplayAllStatistics()
        {
            if (GUILayout.Button("Statistics"))
            {
                showStatisticsOptions = !showStatisticsOptions;
            }
            if (!showStatisticsOptions)
                return;
            if (statisticsManager == null)
            {
                EditorGUILayout.HelpBox("ProjectContext or StatisticsInfoManager not found", MessageType.Error);
                return;
            }

            var statistics = statisticsManager.StatisticInfos;
            foreach (var statistic in statistics)
            {
                activeStatistics[statistic.StatisticName] = EditorGUILayout.Toggle(statistic.StatisticName,
                    activeStatistics[statistic.StatisticName]);
            }
            
            if (GUILayout.Button("Update statistics"))
            {
                UpdateStatistics();
            }
        }
        
        private void UpdateStatistics()
        {
            var dynamicStatisticsController = (StatisticsController) target;

            foreach (var statistic in activeStatistics)
            {
                statistics.RemoveAll(ctg => ctg.StatisticName == statistic.Key && !statistic.Value);
                if (statistic.Value)
                {
                    var exist = statistics.Exists(ctg => ctg.StatisticName == statistic.Key);
                    if(exist)
                        continue;
                    statistics.Add(new DynamicStatisticValue()
                    {
                        StatisticName = statistic.Key,
                        Value = 0
                    });
                }
            }
            
            statistics = statistics.OrderBy(ctg => activeStatistics[ctg.StatisticName]).ToList();
            dynamicStatisticsController.SetStatistics(statistics);
            
            EditorUtility.SetDirty(dynamicStatisticsController);
        }
    }
}