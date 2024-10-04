using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class ConditionSystemBaseController : ResourceSystemBaseController, IConitionable
    {
        public UnityEvent<ConditionInfo> OnStaminaUse = new UnityEvent<ConditionInfo>();
        public UnityEvent<ConditionInfo> OnStaminaRegen = new UnityEvent<ConditionInfo>();
        public UnityEvent OnNotEnoughStamina = new UnityEvent();
    
        public override float PercentValue => CurrentValue / MaxValue;
        public override float MaxValue => statisticsController.GetStatistics().Condition.Value;
        
        private StatisticsController statisticsController;

        protected override void Awake()
        {
            statisticsController = GetComponent<StatisticsController>();
            statisticsController.OnStatisticsChanged.AddListener(InitStamina);
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
            InitAndRegen(0, statisticsController.GetStatistics().Condition.Value);
        }

    
    }
}
