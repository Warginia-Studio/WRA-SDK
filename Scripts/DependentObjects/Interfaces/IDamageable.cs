using WRACore.DependentObjects.Classes;

namespace WRACore.DependentObjects.Interfaces
{
    public interface IDamageable
    {
        void DealDamage(DamageInfo damageInfo);
    }
}