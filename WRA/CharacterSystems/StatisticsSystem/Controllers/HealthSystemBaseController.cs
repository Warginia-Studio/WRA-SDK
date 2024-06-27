using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem.Controllers
{
    [RequireComponent(typeof(StatisticsControler))]
    public class HealthSystemBaseController : ResourceSystemBaseControler, IHealable, IDamageable
    {
        [HideInInspector] public UnityEvent<HealInfo> OnBeforeHeal = new UnityEvent<HealInfo>();
        [HideInInspector] public UnityEvent<HealInfo> OnHealed = new UnityEvent<HealInfo>();

        [HideInInspector] public UnityEvent<DamageInfo> OnBeforeDamage = new UnityEvent<DamageInfo>();
        [HideInInspector] public UnityEvent<DamageInfo> OnDamaged = new UnityEvent<DamageInfo>();

        [HideInInspector] public UnityEvent<KillInfo> OnBeforeKill = new UnityEvent<KillInfo>();
        [HideInInspector] public UnityEvent<KillInfo> OnKilled = new UnityEvent<KillInfo>();

        public bool Immortal { get; private set; }
        public override float PercentValue => CurrentValue / MaxValue;
        public override float MaxValue => statisticsControler.GetStatistics().Health.Value;
        
        private StatisticsControler statisticsControler;

        protected override void Awake()
        {
            statisticsControler = GetComponent<StatisticsControler>();
            statisticsControler.OnStatisticsChanged.AddListener(InitHealth);
            InitHealth();
        }
        
        public void SetImmortal(bool value)
        {
            Immortal = value;
        }
        
        public virtual void Heal(HealInfo healInfo)
        {

            OnBeforeHeal.Invoke(healInfo);
            healInfo.FinalHeal = healInfo.HealValue + CurrentValue * healInfo.PercentHealValueOfCurrentHealth +
                                 MaxValue * healInfo.PercentHealValueOfMaxHealth;
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
                Kill(new KillInfo(damageInfo.Owner));
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
            InitAndRegen(0, statisticsControler.GetStatistics().Health.Value);
        }
    }
}
