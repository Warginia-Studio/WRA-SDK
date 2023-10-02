using WRA.PlayerSystems.LanguageSystem;

namespace WRA.CharacterSystems.StatisticsSystem.Statistics
{
    [System.Serializable]
    public class DynamicStatisticValue
    {
        public DynamicStatisticEnum Statistic;
        public float Value;
        
        public string GetStatisticInString()
        {
            return StatisticsProfile.Instance.StatisticInfos[Statistic.Id].GetStringForStatistic(Value);
        }

        public string GetStatisticTranslation()
        {
            return LanguageManager.GetTranslation("Statistic_" + StatisticsProfile.Instance.StatisticInfos[Statistic.Id].StatisticName);
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
