using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class DynamicStatisticsController : MonoBehaviour
    {
        [SerializeField] private List<DynamicStatisticValue> baseStatistics;

        private void Awake()
        {
            // for (int i = 0; i < baseStatistics.Count; i++)
            // {
            //     Debug.Log(baseStatistics[i].GetStatisticInString());
            // }
        }

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
    }
}
