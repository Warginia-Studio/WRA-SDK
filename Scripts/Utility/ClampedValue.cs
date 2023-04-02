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

        public float LastChangedFixed { get; private set; }
        private float lastRemerValue = 0;

        private float value;
        private float min;
        private float max;

        public ClampedValue(float min, float max)
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

        public static ClampedValue operator +(ClampedValue x, ClampedValue y)
        {
            x.value += y.value;
            x.CheckChange();
            return x;
        }
    
        public static ClampedValue operator -(ClampedValue x, ClampedValue y)
        {
            x.value -= y.value;
            x.CheckChange();
            return x;
        }
    
        public static ClampedValue operator /(ClampedValue x, ClampedValue y)
        {
            x.value /= y.value;
            x.CheckChange();
            return x;
        }
    
        public static ClampedValue operator *(ClampedValue x, ClampedValue y)
        {
            x.value *= y.value;
            x.CheckChange();
            return x;
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
            x.value += y;
            x.CheckChange();
            return x;
        }
    
        public static ClampedValue operator -(ClampedValue x, float y)
        {
            x.value -= y;
            x.CheckChange();
            return x;
        }
    
        public static ClampedValue operator /(ClampedValue x, float y)
        {
            x.value /= y;
            x.CheckChange();
            return x;
        }
    
        public static ClampedValue operator *(ClampedValue x, float y)
        {
            x.value *= y;
            x.CheckChange();
            return x;
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

        private void CheckChange()
        {
            LastChangedFixed = lastRemerValue - value;
            lastRemerValue = value;
        }
    }
}
