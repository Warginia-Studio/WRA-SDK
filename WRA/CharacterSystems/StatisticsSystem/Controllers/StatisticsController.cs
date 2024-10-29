using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class StatisticsController : Transform
    {
        [SerializeField] private List<DynamicStatisticValue> baseStatistics;
        
        public DynamicStatisticValue GetStatistic(int index)
        {
            return baseStatistics[index];
        }
        
        public DynamicStatisticValue GetStatistic(string name)
        {
            for (int i = 0; i < baseStatistics.Count; i++)
            {
                if (baseStatistics[i].StatisticName.ToLower() == name.ToLower())
                {
                    return baseStatistics[i];
                }
            }

            return null;
        }

#if UNITY_EDITOR
        
        public void SetStatistics(List<DynamicStatisticValue> statistics)
        {
            baseStatistics = statistics;
        }
        
        public List<DynamicStatisticValue> GetStatistics()
        {
            return baseStatistics;
        }
#endif
    }
}
