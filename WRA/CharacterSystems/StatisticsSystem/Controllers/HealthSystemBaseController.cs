using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace WRA.CharacterSystems.StatisticsSystem.Controllers
{
    public class HealthSystemBaseController : ResourceSystemBaseController, IHealable, IDamageable
    {
        [HideInInspector] public UnityEvent<HealInfo> OnBeforeHeal = new UnityEvent<HealInfo>();
        [HideInInspector] public UnityEvent<HealInfo> OnHealed = new UnityEvent<HealInfo>();

        [HideInInspector] public UnityEvent<DamageInfo> OnBeforeDamage = new UnityEvent<DamageInfo>();
        [HideInInspector] public UnityEvent<DamageInfo> OnDamaged = new UnityEvent<DamageInfo>();

        [HideInInspector] public UnityEvent<KillInfo> OnBeforeKill = new UnityEvent<KillInfo>();
        [HideInInspector] public UnityEvent<KillInfo> OnKilled = new UnityEvent<KillInfo>();

        public bool Alive => CurrentValue > 0;
        public bool Immortal { get; private set; }
        
        private DynamicStatisticValue maxHealth;
        
        protected override void Awake()
        {
            base.Awake();
            MaxValueStatistic = StatisticsController.GetStatistic("MaxHealth");
            InitHealth();
        }
        
        public void SetImmortal(bool value)
        {
            Immortal = value;
        }
        
        public virtual void Heal(HealInfo healInfo)
        {

            OnBeforeHeal.Invoke(healInfo);
            healInfo.ModifiedValue += healInfo.ModifiedValuePercent * MaxValueStatistic.Value;
            AddValue(healInfo);
            OnHealed.Invoke(healInfo);
        }
        
        /*
         * Here needs amors reduction rules etc.
         */
        
        public virtual void DealDamage(DamageInfo damageInfo)
        {
            if(Immortal)
                return;
            OnBeforeDamage.Invoke(damageInfo);
            RemoveValue(damageInfo);
            OnDamaged.Invoke(damageInfo);
            if(CurrentValue <= 0)
                Kill(new KillInfo(damageInfo.Caster, transform));
        }

        public virtual void Kill(KillInfo killInfo)
        {
            OnBeforeKill.Invoke(killInfo);
            if (!killInfo.WillBeDead)
                return;
            OnKilled.Invoke(killInfo);
        }

        private void InitHealth()
        {
            InitAndRegen(0, MaxValueStatistic.Value);
        }
    }
}
