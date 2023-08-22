using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.Statistics
{
    [System.Serializable]
    public class DynamicStatisticEnum
    {
        public int Id => id;
        [SerializeField] private int id;
    }
}
