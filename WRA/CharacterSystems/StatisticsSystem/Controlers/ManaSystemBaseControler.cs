using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class ManaSystemBaseControler : ResourceSystemBaseControler, IManaable
    {
        public UnityEvent<ManaInfo> OnManaUse = new UnityEvent<ManaInfo>();
        public UnityEvent<ManaInfo> OnManaRegen = new UnityEvent<ManaInfo>();
        public UnityEvent OnNotEnoughMana = new UnityEvent();
    
        public override float PercentValue => CurrentValue / MaxValue;
        public override float MaxValue => statisticsControler.GetStatistics().Mana.Value;
        
        private StatisticsControler statisticsControler;

        protected override void Awake()
        {
            statisticsControler = GetComponent<StatisticsControler>();
            statisticsControler.OnStatisticsChanged.AddListener(InitMana);
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
            InitAndRegen(0, statisticsControler.GetStatistics().Mana.Value);
        }
    
    }
}
