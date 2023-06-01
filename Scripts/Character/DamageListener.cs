using DependentObjects.Classes.ResourcesInfos;
using DependentObjects.Interfaces;
using UnityEngine;
using Utility.CustomAttributes.CustomProperty;

namespace Character
{
    public class DamageListener : MonoBehaviour, IDamageable
    {
        [SerializeField][CSerializedField(true)] private COP<HealthController> healthController;
        [SerializeField] private float scalingDamage = 1;
        public void DealDamage(DamageInfo damageInfo)
        {
            damageInfo.ScalingDamage = scalingDamage;
            healthController.serializedProperty.DealDamage(damageInfo);
        }
    }
}
