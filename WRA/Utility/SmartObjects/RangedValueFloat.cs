using UnityEngine;

namespace WRA.Utility.SmartObjects
{
    [System.Serializable]
    public class RangedValueFloat
    {
        public float Value
        {
            get => value;
            set
            {
                this.value = Mathf.Clamp(value, min, max);
            }
        }
        
        private float value;
        private float min;
        private float max;

        public RangedValueFloat(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public void SetNewValues(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
        
        #region Self_Operators

        public static RangedValueFloat operator +(RangedValueFloat x, RangedValueFloat y)
        {
            x.value += y.value;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static RangedValueFloat operator -(RangedValueFloat x, RangedValueFloat y)
        {
            x.value -= y.value;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static RangedValueFloat operator /(RangedValueFloat x, RangedValueFloat y)
        {
            x.value /= y.value;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static RangedValueFloat operator *(RangedValueFloat x, RangedValueFloat y)
        {
            x.value *= y.value;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
        
        public static bool operator<=(RangedValueFloat x, RangedValueFloat y)
        {
            return x.value <= y.value;
        }
    
        public static bool operator>=(RangedValueFloat x, RangedValueFloat y)
        {
            return x.value >= y.value;
        }
        #endregion

        #region Float_Operators
        
        public static RangedValueFloat operator +(RangedValueFloat x, float y)
        {
            x.value += y;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static RangedValueFloat operator -(RangedValueFloat x, float y)
        {
            x.value -= y;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static RangedValueFloat operator /(RangedValueFloat x, float y)
        {
            x.value /= y;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static RangedValueFloat operator *(RangedValueFloat x, float y)
        {
            x.value *= y;
            x.value = Mathf.Clamp(x.value, x.min, x.max);
            return x;
        }
    
        public static bool operator==(RangedValueFloat x, float y)
        {
            return x.value == y;
        }
    
        public static bool operator!=(RangedValueFloat x, float y)
        {
            return x.value != y;
        }
    
        public static bool operator<=(RangedValueFloat x, float y)
        {
            return x.value <= y;
        }
    
        public static bool operator>=(RangedValueFloat x, float y)
        {
            return x.value >= y;
        }

        #endregion
    }
}
