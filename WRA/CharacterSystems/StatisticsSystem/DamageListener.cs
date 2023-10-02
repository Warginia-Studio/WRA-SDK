using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class DamageListener : MonoBehaviour, IDamageable
    {
        [SerializeField] private float scalingDamage = 1;
        
        private HealthSystemBaseControler healthSystemBaseController;

        private void Awake()
        {
            healthSystemBaseController = GetComponentInParent<HealthSystemBaseControler>();
        }

        public void DealDamage(DamageInfo damageInfo)
        {
            damageInfo.ScalingDamage = scalingDamage;
            healthSystemBaseController.DealDamage(damageInfo);
        }
    }
}
