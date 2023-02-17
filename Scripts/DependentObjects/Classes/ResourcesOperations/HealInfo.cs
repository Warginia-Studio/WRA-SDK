using UnityEngine;

namespace DependentObjects.Classes
{
    public class HealInfo : ResourcesChangedBase
    {
        public float HealValue;
        public float PercentHealValueOfMaxHealth;
        public float PercentHealValueOfCurrentHealth;
        public float FinalHeal;

        public void BuffHeal(float multyiply)
        {
            HealValue *= multyiply;
            PercentHealValueOfCurrentHealth *= multyiply;
            PercentHealValueOfMaxHealth *= multyiply;
        }
    }
}