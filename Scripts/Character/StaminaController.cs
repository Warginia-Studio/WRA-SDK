using DependentObjects.Interfaces;
using UnityEngine.Events;

namespace Character
{
    public class StaminaController : SourceController, IStaminaable
    {
        public UnityEvent<float> OnStaminaUse = new UnityEvent<float>();
        public UnityEvent<float> OnStaminaRegen = new UnityEvent<float>();
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

        public bool TryUseStamina(float stamina)
        {
            if (CurrentValue < stamina)
            {
                OnNotEnoughStamina.Invoke();
                return false;
            }

            RemoveValue(stamina);
            OnStaminaUse.Invoke(stamina);
            return true;
        }

        public void RegenStamina(float stamina)
        {
            throw new System.NotImplementedException();
        }

        private void InitStamina()
        {
            InitAndRegen(0, statisticsController.GetStatistics().Condition.Value);
        }

    
    }
}
