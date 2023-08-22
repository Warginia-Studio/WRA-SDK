using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public interface IConitionable
    {
        bool TryUseStamina(ConditionInfo stamina);
    
        void RegenStamina(ConditionInfo stamina);
    }
}
