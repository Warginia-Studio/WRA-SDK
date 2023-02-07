using UnityEngine;

namespace WRACore.Utility
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
    }
}
