using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class ConditionControler : ResourceControler, IConitionable
    {
        public UnityEvent<ConditionInfo> OnStaminaUse = new UnityEvent<ConditionInfo>();
        public UnityEvent<ConditionInfo> OnStaminaRegen = new UnityEvent<ConditionInfo>();
        public UnityEvent OnNotEnoughStamina = new UnityEvent();
    
        public override float PercentValue => CurrentValue / MaxValue;
        public override float MaxValue => statisticsControler.GetStatistics().Condition.Value;
        
        private StatisticsControler statisticsControler;

        protected override void Awake()
        {
            statisticsControler = GetComponent<StatisticsControler>();
            statisticsControler.OnStatisticsChanged.AddListener(InitStamina);
            InitStamina();
        }

        public bool TryUseStamina(ConditionInfo stamina)
        {
            if (CurrentValue < stamina.CalculatedValueChanged)
            {
                OnNotEnoughStamina.Invoke();
                return false;
            }

            RemoveValue(stamina);
            OnStaminaUse.Invoke(stamina);
            return true;
        }

        public void RegenStamina(ConditionInfo stamina)
        {
            AddValue(stamina);
        }

        private void InitStamina()
        {
            InitAndRegen(0, statisticsControler.GetStatistics().Condition.Value);
        }

    
    }
}
