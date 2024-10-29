using UnityEngine;

namespace WRA.CharacterSystems.StatisticsSystem.ResourcesInfos
{
    public class HealInfo : ResourcesChangedBase
    {
        public float HealValue;
        public float PercentHealValueOfMaxHealth;
        public float PercentHealValueOfCurrentHealth;
        public float FinalHeal;

        public HealInfo(Transform caster, Transform target, float modifiedValue, float healValue, float percentHealValueOfMaxHealth, float percentHealValueOfCurrentHealth, float finalHeal) : base(caster, target, modifiedValue)
        {
            HealValue = healValue;
            PercentHealValueOfMaxHealth = percentHealValueOfMaxHealth;
            PercentHealValueOfCurrentHealth = percentHealValueOfCurrentHealth;
            FinalHeal = finalHeal;
        }

        public void BuffHeal(float multyiply)
        {
            HealValue *= multyiply;
            PercentHealValueOfCurrentHealth *= multyiply;
            PercentHealValueOfMaxHealth *= multyiply;
        }
    }
}