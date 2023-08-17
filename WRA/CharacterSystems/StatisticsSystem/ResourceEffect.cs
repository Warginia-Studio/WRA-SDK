using UnityEngine;
using WRA.General.Effects;
using WRA.Utility.CustomAttributes.CustomProperty;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class ResourceEffect : MonoBehaviour
    {
        [SerializeField] [CSerializedField(true)]
        private COP<ResourceController> targetResource;
    
        [SerializeField] public EffectBehaviourBase onIncreasedEffect;
        [SerializeField] public EffectBehaviourBase onDecreaseEffect;
        [SerializeField] public EffectBehaviourBase onChangedEffect;
    
        private void Awake()
        {
            if (targetResource == null)
                return;
        
            if (onDecreaseEffect!=null)
                targetResource.serializedProperty.OnDecreaseValue.AddListener((ctg) => onDecreaseEffect.PlayEffect(transform));
            if(onIncreasedEffect !=null)
                targetResource.serializedProperty.OnIncreaseValue.AddListener((ctg) => onIncreasedEffect.PlayEffect(transform));
            if(onChangedEffect!=null)
                targetResource.serializedProperty.OnIncreaseValue.AddListener((ctg) => onChangedEffect.PlayEffect(transform));
        }
    }
}
