using UnityEngine;

namespace Utility
{
    public class ClampedValue
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

        public ClampedValue(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        #region Self_Operators

        public static ClampedValue operator +(ClampedValue x, ClampedValue y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value + y.value;
            return clampedValue;
        }
    
        public static ClampedValue operator -(ClampedValue x, ClampedValue y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value - y.value;
            return clampedValue;
        }
    
        public static ClampedValue operator /(ClampedValue x, ClampedValue y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value / y.value;
            return clampedValue;
        }
    
        public static ClampedValue operator *(ClampedValue x, ClampedValue y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value * y.value;
            return clampedValue;
        }
    
        public static bool operator==(ClampedValue x, ClampedValue y)
        {
            return x.value == y.value;
        }
    
        public static bool operator!=(ClampedValue x, ClampedValue y)
        {
            return x.value != y.value;
        }
    
        public static bool operator<=(ClampedValue x, ClampedValue y)
        {
            return x.value <= y.value;
        }
    
        public static bool operator>=(ClampedValue x, ClampedValue y)
        {
            return x.value >= y.value;
        }
        #endregion

        #region Float_Operators
        
        public static ClampedValue operator +(ClampedValue x, float y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value + y;
            return clampedValue;
        }
    
        public static ClampedValue operator -(ClampedValue x, float y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value - y;
            return clampedValue;
        }
    
        public static ClampedValue operator /(ClampedValue x, float y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value / y;
            return clampedValue;
        }
    
        public static ClampedValue operator *(ClampedValue x, float y)
        {
            ClampedValue clampedValue = new ClampedValue(x.min, x.max);
            clampedValue.value = x.value * y;
            return clampedValue;
        }
    
        public static bool operator==(ClampedValue x, float y)
        {
            return x.value == y;
        }
    
        public static bool operator!=(ClampedValue x, float y)
        {
            return x.value != y;
        }
    
        public static bool operator<=(ClampedValue x, float y)
        {
            return x.value <= y;
        }
    
        public static bool operator>=(ClampedValue x, float y)
        {
            return x.value >= y;
        }

        #endregion
    }
}
