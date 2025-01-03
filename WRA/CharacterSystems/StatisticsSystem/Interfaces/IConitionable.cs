using WRA.CharacterSystems.Data;

namespace WRA.CharacterSystems.StatisticsSystem.Interfaces
{
    public interface IConitionable
    {
        bool TryUseStamina(ConditionInfo stamina);
    
        void RegenStamina(ConditionInfo stamina);
    }
}
