using UnityEngine;

namespace DependentObjects.Structs
{
    [System.Serializable]
    public struct StatisticInfo
    {
        [SerializeField] public Color StatisticColor;
        [SerializeField] public string StatisticName;


        public StatisticInfo(Color c)
        {
            StatisticColor = c;
            StatisticName = "";
        }
    }
}