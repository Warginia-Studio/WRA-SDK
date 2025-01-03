using System;
using UnityEngine;
using WRA.CharacterSystems.Data;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;

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
            healthSystemBaseController.DealDamage(damageInfo);
        }
    }
}
