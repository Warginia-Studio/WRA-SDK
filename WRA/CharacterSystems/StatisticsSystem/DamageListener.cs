using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class DamageListener : MonoBehaviour, IDamageable
    {
        public bool Immortal => healthSystemBaseController.Immortal;
        
        [SerializeField] private float scalingDamage = 1;
        
        private HealthSystemBaseController healthSystemBaseController;

        private void Awake()
        {
            healthSystemBaseController = GetComponentInParent<HealthSystemBaseController>();
        }
        
        public void DealDamage(DamageInfo damageInfo)
        {
            damageInfo.ScalingDamage = scalingDamage;
            healthSystemBaseController.DealDamage(damageInfo);
        }
    }
}
