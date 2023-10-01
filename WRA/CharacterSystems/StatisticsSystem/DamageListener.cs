using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class DamageListener : MonoBehaviour, IDamageable
    {
        [SerializeField] private float scalingDamage = 1;
        
        private HealthControler healthController;

        private void Awake()
        {
            healthController = GetComponentInParent<HealthControler>();
        }

        public void DealDamage(DamageInfo damageInfo)
        {
            damageInfo.ScalingDamage = scalingDamage;
            healthController.DealDamage(damageInfo);
        }
    }
}
