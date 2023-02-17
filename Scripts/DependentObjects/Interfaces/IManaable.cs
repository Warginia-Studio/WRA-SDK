using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;

namespace DependentObjects.Interfaces
{
    public interface IManaable
    {
        bool TryUseMana(ManaInfo mana);
    
        void RegenMana(ManaInfo mana);
    }
}
