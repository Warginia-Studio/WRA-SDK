using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem.Interfaces
{
    public interface IManaable
    {
        bool TryUseMana(ManaInfo mana);
    
        void RegenMana(ManaInfo mana);
    }
}
