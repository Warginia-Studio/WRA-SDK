using DependentObjects.Classes;

namespace DependentObjects.Interfaces
{
    public interface IConitionable
    {
        bool TryUseStamina(ConditionInfo stamina);
    
        void RegenStamina(ConditionInfo stamina);
    }
}
