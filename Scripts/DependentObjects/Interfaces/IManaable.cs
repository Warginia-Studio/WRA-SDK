namespace DependentObjects.Interfaces
{
    public interface IManaable
    {
        bool TryUseMana(float mana);
    
        void RegenMana(float mana);
    }
}
