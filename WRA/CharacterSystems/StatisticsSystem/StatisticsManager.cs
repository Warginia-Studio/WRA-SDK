using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class StatisticsManager : MonoBehaviour
    {
        public List<StatisticInfo> StatisticInfos => statisticInfos;
        
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
