using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class StatisticsController : CharacterSystemBase
    {
        public UnityEvent OnStatisticsChanged = new UnityEvent();
        
        [SerializeField] private StatisticsHolder baseStatistics;

        [SerializeField] private List<DynamicStatisticValue> statValues;
        
        
        public StatisticsHolder GetStatistics()
        {
            return baseStatistics;
        }
    }
}
