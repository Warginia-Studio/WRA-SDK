using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem.Interfaces
{
    public interface IDamageable
    {
        public bool Immortal { get; }
        void DealDamage(DamageInfo damageInfo);
    }
}