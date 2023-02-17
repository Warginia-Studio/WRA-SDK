using DependentObjects.Classes;

namespace DependentObjects.Interfaces
{
    public interface IManaable
    {
        bool TryUseMana(ManaInfo mana);
    
        void RegenMana(ManaInfo mana);
    }
}
