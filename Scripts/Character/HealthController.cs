using DependentObjects.Classes;
using DependentObjects.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    [RequireComponent(typeof(StatisticsController))]
    public class HealthController : SourceController, IHealable, IDamageable
    {
        public UnityEvent<HealInfo> OnBeforeHeal = new UnityEvent<HealInfo>();
        public UnityEvent<HealInfo> OnHealed = new UnityEvent<HealInfo>();

        public UnityEvent<DamageInfo> OnBeforeDamage = new UnityEvent<DamageInfo>();
        public UnityEvent<DamageInfo> OnDamaged = new UnityEvent<DamageInfo>();

        public UnityEvent<KillInfo> OnBeforeKill = new UnityEvent<KillInfo>();
        public UnityEvent<KillInfo> OnKilled = new UnityEvent<KillInfo>();

        public override float PercentValue => CurrentValue / MaxValue;
        public override float MaxValue => statisticsController.GetStatistics().Health.Value;
        
        private StatisticsController statisticsController;

        protected override void Awake()
        {
            statisticsController = GetComponent<StatisticsController>();
            statisticsController.OnStatisticsChanged.AddListener(InitHealth);
            InitHealth();
        }
        
        public virtual void Heal(HealInfo healInfo)
        {
            OnBeforeHeal.Invoke(healInfo);
            healInfo.FinalHeal = healInfo.HealValue + CurrentValue * healInfo.PercentHealValueOfCurrentHealth +
                                 MaxValue * healInfo.PercentHealValueOfMaxHealth;
            AddValue(healInfo.FinalHeal);
            OnHealed.Invoke(healInfo);
        }
        
        /*
         * Here needs amors reduction rules etc.
         */

        public virtual void DealDamage(DamageInfo damageInfo)
        {
            OnBeforeDamage.Invoke(damageInfo);
            RemoveValue(damageInfo.PhysicalDamage);
            OnDamaged.Invoke(damageInfo);
        }

        public virtual void Kill(KillInfo killInfo)
        {
            OnBeforeKill.Invoke(killInfo);
            OnKilled.Invoke(killInfo);
        }

        private void InitHealth()
        {
            InitAndRegen(0, statisticsController.GetStatistics().Health.Value);
        }
    }
}
