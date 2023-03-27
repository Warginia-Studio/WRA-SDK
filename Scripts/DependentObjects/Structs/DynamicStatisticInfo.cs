using System;
using UnityEngine;
using Utility;

namespace DependentObjects.Structs
{
    [System.Serializable]
    public class DynamicStatisticInfo
    {
        private const string BOLD_BASE = "<b>{0}</b>";
        private const string COLOR_BASE = "<color={0}>{1}</color>";
        public string StatisticName;
        [SerializeField] private bool BoldText;
        [SerializeField] Color ColorText = Color.white;
        [SerializeField] string Formating;


        public string GetStringForStatistic(float value)
        {
            var str = "";
            str = String.Format(COLOR_BASE, ColorToHex.GetHexColor(ColorText), value.ToString(Formating));
            return String.Format(BOLD_BASE, str);
        }
    }
}
