using UnityEngine;

namespace DependentObjects.Classes
{
    public class DamageInfo
    {
        public float PhysicalDamage;
        public float FireDamage;
        public float IceDamage;
        public bool CriticalHit;
        public bool CanBeReflected;
        
        public Transform Owner;
        
        public float DealtDamage = 0;
    }
}