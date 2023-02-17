using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;
using DependentObjects.Interfaces;
using UnityEngine.Events;

namespace Character
{
    public class ManaController : ResourceController, IManaable
    {
        public UnityEvent<ManaInfo> OnManaUse = new UnityEvent<ManaInfo>();
        public UnityEvent<ManaInfo> OnManaRegen = new UnityEvent<ManaInfo>();
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

        public bool TryUseMana(ManaInfo mana)
        {
            if (CurrentValue < mana.CalculatedValueChanged)
            {
                OnNotEnoughMana.Invoke();
                return false;
            }

            RemoveValue(mana);
            OnManaUse.Invoke(mana);
            return true;
        }

        public void RegenMana(ManaInfo mana)
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
