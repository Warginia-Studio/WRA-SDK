using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public interface IDamageable
    {
        void DealDamage(DamageInfo damageInfo);
    }
}