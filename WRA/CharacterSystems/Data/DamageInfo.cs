using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class DamageInfo : ResourcesChangedBase
    {
        public float PhysicalDamage;
        public float FireDamage;
        public float IceDamage;
        public bool CriticalHit;
        public bool CanBeReflected;
        
        public float DealtDamage = 0;
        public float ScalingDamage = 1;

        public bool containsHitPosition;

        public DamageInfo(float physicalDamage, float fireDamage, float iceDamage, bool criticalHit, bool canBeReflected, float dealtDamage, float scalingDamage, bool containsHitPosition, Vector3 hitedPosition, Transform caster, Transform target, float modifiedValue = 0, float modifiedValuePercent = 0) : base(caster, target, modifiedValue, modifiedValuePercent)
        {
            PhysicalDamage = physicalDamage;
            FireDamage = fireDamage;
            IceDamage = iceDamage;
            CriticalHit = criticalHit;
            CanBeReflected = canBeReflected;
            DealtDamage = dealtDamage;
            ScalingDamage = scalingDamage;
            this.containsHitPosition = containsHitPosition;
            this.hitedPosition = hitedPosition;
        }

        public Vector3 HitedPosition
        {
            get
            {
                return hitedPosition;
            }

            set
            {
                hitedPosition = value;
                containsHitPosition = true;
            }
        }

        private Vector3 hitedPosition;
    }
}