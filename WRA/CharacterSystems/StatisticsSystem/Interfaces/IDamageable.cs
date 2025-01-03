using WRA.CharacterSystems.Data;

namespace WRA.CharacterSystems.StatisticsSystem.Interfaces
{
    public interface IDamageable
    {
        public bool Immortal { get; }
        void DealDamage(DamageInfo damageInfo);
    }
}