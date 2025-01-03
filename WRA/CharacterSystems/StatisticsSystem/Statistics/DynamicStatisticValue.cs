using UnityEngine.Serialization;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.General.Language;

namespace WRA.CharacterSystems.StatisticsSystem.Statistics
{
    [System.Serializable]
    public class DynamicStatisticValue
    {
        public string StatisticName;
        public float Value;


        private DynamicStatisticInfo dynamicStatisticInfo;
        public DynamicStatisticValue()
        {
            // dynamicStatisticInfo = StatisticsProfile.Instance.StatisticInfos.Find(ctg => ctg.StatisticName == StatisticName);
        }
        
        public string GetStatisticInString()
        {
            return dynamicStatisticInfo.GetStringForStatistic(Value);
        }

        public string GetStatisticTranslation()
        {
            return LanguageManager.GetTranslation("Statistic_" + dynamicStatisticInfo.StatisticName);
        }

        public string GetFullText()
        {
            return GetStatisticTranslation() + ": " + GetStatisticInString();
        }

        #region DynamicStaticValue_Operators_Modificators
    
        public static DynamicStatisticValue operator +(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            dsv1.Value += dsv2.Value;
            return dsv1;
        }
    
        public static DynamicStatisticValue operator -(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            dsv1.Value -= dsv2.Value;
            return dsv1;
        }
    
        public static DynamicStatisticValue operator *(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            dsv1.Value *= dsv2.Value;
            return dsv1;
        }
    
        public static DynamicStatisticValue operator /(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            dsv1.Value /= dsv2.Value;
            return dsv1;
        }
    
        #endregion

        #region Float_Operators_Modificators
    
        public static DynamicStatisticValue operator +(DynamicStatisticValue dsv1, float dsv2)
        {
            dsv1.Value += dsv2;
            return dsv1;
        }
    
        public static DynamicStatisticValue operator -(DynamicStatisticValue dsv1, float dsv2)
        {
            dsv1.Value -= dsv2;
            return dsv1;
        }
    
        public static DynamicStatisticValue operator *(DynamicStatisticValue dsv1, float dsv2)
        {
            dsv1.Value *= dsv2;
            return dsv1;
        }
    
        public static DynamicStatisticValue operator /(DynamicStatisticValue dsv1, float dsv2)
        {
            dsv1.Value /= dsv2;
            return dsv1;
        }
        #endregion

        #region Logical_DynamicStatisticValues
    
        public static bool operator ==(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            return dsv1.Value == dsv2.Value;
        }
    
        public static bool operator !=(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            return dsv1.Value != dsv2.Value;
        }
    
        public static bool operator >=(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            return dsv1.Value >= dsv2.Value;
        }
    
        public static bool operator <=(DynamicStatisticValue dsv1, DynamicStatisticValue dsv2)
        {
            return dsv1.Value <= dsv2.Value;
        }
    
        #endregion

        #region Logical_Floats
    
        public static bool operator ==(DynamicStatisticValue dsv1, float dsv2)
        {
            return dsv1.Value == dsv2;
        }
    
        public static bool operator !=(DynamicStatisticValue dsv1, float dsv2)
        {
            return dsv1.Value != dsv2;
        }
    
        public static bool operator >=(DynamicStatisticValue dsv1, float dsv2)
        {
            return dsv1.Value >= dsv2;
        }
    
        public static bool operator <=(DynamicStatisticValue dsv1, float dsv2)
        {
            return dsv1.Value <= dsv2;
        }
    
        #endregion
    }
}
