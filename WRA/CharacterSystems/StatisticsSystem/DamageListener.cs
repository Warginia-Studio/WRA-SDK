using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.Utility.CustomAttributes.CustomProperty;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class DamageListener : MonoBehaviour, IDamageable
    {
        [SerializeField][CSerializedField(true)] private COP<HealthControler> healthController;
        [SerializeField] private float scalingDamage = 1;
        public void DealDamage(DamageInfo damageInfo)
        {
            damageInfo.ScalingDamage = scalingDamage;
            healthController.serializedProperty.DealDamage(damageInfo);
        }
    }
}
