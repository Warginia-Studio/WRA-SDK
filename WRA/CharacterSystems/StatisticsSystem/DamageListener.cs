using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class DamageListener : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthControler healthController;
        [SerializeField] private float scalingDamage = 1;
        public void DealDamage(DamageInfo damageInfo)
        {
            damageInfo.ScalingDamage = scalingDamage;
            healthController.DealDamage(damageInfo);
        }
    }
}
