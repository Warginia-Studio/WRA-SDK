using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;

namespace DependentObjects.Interfaces
{
    public interface IHealable
    {
        void Heal(HealInfo healInfo);
    }
}
