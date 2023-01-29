using DependentObjects.Classes;
using Utility;

namespace DependentObjects.Interfaces
{
    public interface IDamageable
    {
        void DealDamage(DamageInfo damageInfo);
    }
}