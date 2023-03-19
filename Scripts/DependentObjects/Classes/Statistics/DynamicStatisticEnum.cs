using UnityEngine;

namespace DependentObjects.Classes.Statistics
{
    [System.Serializable]
    public class DynamicStatisticEnum
    {
        public int Id => id;
        [SerializeField] private int id;
    }
}
