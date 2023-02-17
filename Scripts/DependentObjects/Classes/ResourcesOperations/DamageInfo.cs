using UnityEngine;

namespace DependentObjects.Classes
{
    public class DamageInfo : ResourcesChangedBase
    {
        public float PhysicalDamage;
        public float FireDamage;
        public float IceDamage;
        public bool CriticalHit;
        public bool CanBeReflected;
        
        public float DealtDamage = 0;
    }
}