using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public class ManaSystemBaseController : ResourceSystemBaseController, IManaable
    {
        public UnityEvent<ManaInfo> OnManaUse = new UnityEvent<ManaInfo>();
        public UnityEvent<ManaInfo> OnManaRegen = new UnityEvent<ManaInfo>();
        public UnityEvent OnNotEnoughMana = new UnityEvent();
        

        protected override void Awake()
        {
            MaxValueStatistic = StatisticsController.GetStatistic("MaxMana");
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
            InitAndRegen(0, MaxValueStatistic.Value);
        }
    
    }
}
