using UnityEngine;

namespace WRA.Utility.CustomTypes
{
    public class RangedValueInt
    {
        public int Value
        {
            get => value;
            set
            {
                this.value = Mathf.Clamp(value, min, max);
            }
        }

        public bool LoopValue => loopValue;
        
        private int value;
        private int min;
        private int max;
        private bool loopValue;

        public RangedValueInt(int min, int max, bool loopValue = false)
        {
            SetNewValues(min,max, loopValue);
            SetLoopValue(loopValue);
        }

        public void SetNewValues(int minInclusive, int maxInclusive, bool loopValue = false)
        {
            this.min = minInclusive;
            this.max = maxInclusive;
        }

        public void SetLoopValue(bool loopValue)
        {
            this.loopValue = loopValue;
        }

        public void Next()
        {
            value++;
        }

        public void Previous()
        {
            value--;
        }

        private void CheckValue()
        {
            (int under, int over) borderRule = loopValue ? (max, min) : (min, max);
            
            value = value < min ? borderRule.under : value;
            value = value > max ? borderRule.over : value;
        }
        
        #region Self_Operators

        public static RangedValueInt operator +(RangedValueInt x, RangedValueInt y)
        {
            x.value += y.value;
            return x;
        }
    
        public static RangedValueInt operator -(RangedValueInt x, RangedValueInt y)
        {
            x.value -= y.value;
            return x;
        }
    
        public static RangedValueInt operator /(RangedValueInt x, RangedValueInt y)
        {
            x.value /= y.value;
            return x;
        }
    
        public static RangedValueInt operator *(RangedValueInt x, RangedValueInt y)
        {
            x.value *= y.value;
            return x;
        }
        
        public static bool operator<=(RangedValueInt x, RangedValueInt y)
        {
            return x.value <= y.value;
        }
    
        public static bool operator>=(RangedValueInt x, RangedValueInt y)
        {
            return x.value >= y.value;
        }
        #endregion

        #region int_Operators
        
        public static RangedValueInt operator +(RangedValueInt x, int y)
        {
            x.value += y;
            return x;
        }
    
        public static RangedValueInt operator -(RangedValueInt x, int y)
        {
            x.value -= y;
            return x;
        }
    
        public static RangedValueInt operator /(RangedValueInt x, int y)
        {
            x.value /= y;
            return x;
        }
    
        public static RangedValueInt operator *(RangedValueInt x, int y)
        {
            x.value *= y;
            return x;
        }
    
        public static bool operator==(RangedValueInt x, int y)
        {
            return x.value == y;
        }
    
        public static bool operator!=(RangedValueInt x, int y)
        {
            return x.value != y;
        }
    
        public static bool operator<=(RangedValueInt x, int y)
        {
            return x.value <= y;
        }
    
        public static bool operator>=(RangedValueInt x, int y)
        {
            return x.value >= y;
        }

        #endregion
    }
}
