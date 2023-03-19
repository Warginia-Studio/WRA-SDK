using DependentObjects.Structs;
using UnityEngine;

namespace DependentObjects.Classes
{
    [System.Serializable]
    public struct StatValue
    {
        public bool IsPercent => isPercent;
        
        private bool asInt;
        private bool isPercent;

        public float Value
        {
            get
            {
                return asInt ? (int)statValue : statValue;
            }

            set
            {
                statValue = value;
            }
        }

        [SerializeField] private float statValue;
    
        public StatValue(bool asInt, bool isPercent)
        {
            this.asInt = asInt;
            this.isPercent = isPercent;
            statValue = 0;
        }
    
        public static StatValue operator+(StatValue first, StatValue second)
        {
            first.statValue += second.statValue;
            return first;
        }
    
        public static StatValue operator-(StatValue first, StatValue second)
        {
            first.statValue -= second.statValue;
            return first;
        }

        public static StatValue operator +(StatValue first, float value)
        {
            first.statValue = value;
            return first;
        }
        
        public static StatValue operator -(StatValue first, float value)
        {
            first.statValue = value;
            return first;
        }
    
        public static StatValue operator/(StatValue first, StatValue second)
        {
            first.statValue /= second.statValue;
            return first;
        }
    
        public static StatValue operator*(StatValue first, StatValue second)
        {
            first.statValue *= second.statValue;
            return first;
        }
    
        public static StatValue operator%(StatValue first, StatValue second)
        {
            first.statValue %= second.statValue;
            return first;
        }
    
        public static bool operator<(StatValue first, StatValue second)
        {
            return first.statValue < second.statValue;
        }
    
        public static bool operator>(StatValue first, StatValue second)
        {
            return first.statValue > second.statValue;
        }
    }
}
