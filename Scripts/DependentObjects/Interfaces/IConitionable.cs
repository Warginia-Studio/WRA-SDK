using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;

namespace DependentObjects.Interfaces
{
    public interface IConitionable
    {
        bool TryUseStamina(ConditionInfo stamina);
    
        void RegenStamina(ConditionInfo stamina);
    }
}
