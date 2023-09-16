using UnityEngine;
using WRA.General.Effects;
using WRA.Utility.CustomAttributes.CustomProperty;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class ResourceEffect : MonoBehaviour
    {
        [SerializeField] [CSerializedField(true)]
        private COP<ResourceControler> targetResource;
    
        [SerializeField] protected EffectBehaviourBase onIncreasedEffect;
        [SerializeField] protected EffectBehaviourBase onDecreaseEffect;
        [SerializeField] protected EffectBehaviourBase onChangedEffect;
    
        protected virtual void Awake()
        {
            if (targetResource == null)
                return;
        
            if (onDecreaseEffect!=null)
                targetResource.serializedProperty.OnDecreaseValue.AddListener((ctg) => onDecreaseEffect.PlayEffect(transform.position));
            if(onIncreasedEffect !=null)
                targetResource.serializedProperty.OnIncreaseValue.AddListener((ctg) => onIncreasedEffect.PlayEffect(transform.position));
            if(onChangedEffect!=null)
                targetResource.serializedProperty.OnValueChanged.AddListener((ctg) => onChangedEffect.PlayEffect(transform.position));
        }
    }
}
