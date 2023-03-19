namespace DependentObjects.Classes.Statistics
{
    [System.Serializable]
    public class DynamicStatisticValue
    {
        public DynamicStatisticEnum Statistic;
        public float Value;

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
