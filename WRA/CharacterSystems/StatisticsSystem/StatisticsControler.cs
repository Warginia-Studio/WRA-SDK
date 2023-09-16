using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class StatisticsControler : MonoBehaviour
    {
        public UnityEvent OnStatisticsChanged = new UnityEvent();
    
    
        [SerializeField] private StatisticsHolder baseStatistics;


        public StatisticsHolder GetStatistics()
        {
            return baseStatistics;
        }
    }
}
