using UnityEngine;

namespace DependentObjects.Classes
{
    public class HealInfo
    {
        public float HealValue;
        public float PercentHealValueOfMaxHealth;
        public float PercentHealValueOfCurrentHealth;
        public float FinalHeal;
        
        public Transform Owner;

        public void BuffHeal(float multyiply)
        {
            HealValue *= multyiply;
            PercentHealValueOfCurrentHealth *= multyiply;
            PercentHealValueOfMaxHealth *= multyiply;
        }
    }
}