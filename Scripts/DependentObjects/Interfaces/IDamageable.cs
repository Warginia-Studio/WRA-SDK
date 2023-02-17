using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;

namespace DependentObjects.Interfaces
{
    public interface IDamageable
    {
        void DealDamage(DamageInfo damageInfo);
    }
}