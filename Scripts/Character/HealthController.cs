using UnityEngine;
using UnityEngine.Events;
using WRACore.DependentObjects.Classes;
using WRACore.DependentObjects.Interfaces;

namespace WRACore.Character
{
    public class HealthController : MonoBehaviour, IHealable, IDamageable
    {
        public UnityEvent<HealInfo> OnBeforeHeal = new UnityEvent<HealInfo>();
        public UnityEvent<HealInfo> OnHealed = new UnityEvent<HealInfo>();

        public UnityEvent<DamageInfo> OnBeforeDamage = new UnityEvent<DamageInfo>();
        public UnityEvent<DamageInfo> OnDamaged = new UnityEvent<DamageInfo>();

        public UnityEvent<DamageInfo> OnBeforeKill = new UnityEvent<DamageInfo>();
        public UnityEvent<DamageInfo> OnKilled = new UnityEvent<DamageInfo>();

        public void Heal(HealInfo healInfo)
        {
            throw new System.NotImplementedException();
        }

        public void DealDamage(DamageInfo damageInfo)
        {
            throw new System.NotImplementedException();
        }

        public void Kill(DamageInfo damageInfo)
        {
        
        }
    }
}
