using System.Collections.Generic;
using DependentObjects.Structs;
using Patterns;
using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    public class StatisticsInfoManager : ScriptableSingleton<StatisticsInfoManager>
    {
        [SerializeField] private List<StatisticInfo> statisticInfos = new List<StatisticInfo>();

        public StatisticInfo GetStatisticInfo(string statisticName)
        {
            var id = statisticInfos.FindIndex(ctg => ctg.StatisticName == statisticName);
            if (id == -1)
            {
                return new StatisticInfo(Color.white);
            }

            return statisticInfos[id];
        }

        public string GetStatisticName(string statisticName, float value)
        {
            var id = statisticInfos.FindIndex(ctg => ctg.StatisticName == statisticName);
            if (id == -1)
            {
                return new StatisticInfo(Color.white).GetStringWithStat(value);
            }

            return statisticInfos[id].GetStringWithStat(value);
        }
    }
}
