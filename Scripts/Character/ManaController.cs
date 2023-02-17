using DependentObjects.Interfaces;
using UnityEngine.Events;

namespace Character
{
    public class ManaController : SourceController, IManaable
    {
        public UnityEvent<float> OnManaUse = new UnityEvent<float>();
        public UnityEvent<float> OnManaRegen = new UnityEvent<float>();
        public UnityEvent OnNotEnoughMana = new UnityEvent();
    
        public override float PercentValue => CurrentValue / MaxValue;
        public override float MaxValue => statisticsController.GetStatistics().Mana.Value;
        
        private StatisticsController statisticsController;

        protected override void Awake()
        {
            statisticsController = GetComponent<StatisticsController>();
            statisticsController.OnStatisticsChanged.AddListener(InitMana);
            InitMana();
        }

        public bool TryUseMana(float mana)
        {
            if (CurrentValue < mana)
            {
                OnNotEnoughMana.Invoke();
                return false;
            }

            RemoveValue(mana);
            OnManaUse.Invoke(mana);
            return true;
        }

        public void RegenMana(float mana)
        {
            AddValue(mana);
            OnManaRegen.Invoke(mana);
        }

        private void InitMana()
        {
            InitAndRegen(0, statisticsController.GetStatistics().Mana.Value);
        }
    
    }
}
