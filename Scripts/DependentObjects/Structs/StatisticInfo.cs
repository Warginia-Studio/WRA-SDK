using Unity.VisualScripting;
using UnityEngine;

namespace DependentObjects.Structs
{
    [System.Serializable]
    public struct StatisticInfo
    {
        public string StatisticName => statisticName;
        
        [SerializeField] private Color StatisticColor;
        [SerializeField] private string statisticName;
        [SerializeField] private string additionalChar;
        [SerializeField] private string formating;


        public StatisticInfo(Color c)
        {
            StatisticColor = c;
            statisticName = "";
            formating = "0";
            additionalChar = "";
        }

        public string GetStringWithStat(float stat)
        {
            return $"<color={StatisticColor.ToHexString()}>{stat.ToString(formating)} {additionalChar}</color>";
        }
    }
}