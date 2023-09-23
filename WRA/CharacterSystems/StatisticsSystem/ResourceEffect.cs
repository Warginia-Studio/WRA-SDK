using UnityEngine;
using WRA.General.Effects;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class ResourceEffect : MonoBehaviour
    {
        [SerializeField] private ResourceControler targetResource;
    
        [SerializeField] protected EffectBehaviourBase onIncreasedEffect;
        [SerializeField] protected EffectBehaviourBase onDecreaseEffect;
        [SerializeField] protected EffectBehaviourBase onChangedEffect;
    
        protected virtual void Awake()
        {
            if (targetResource == null)
                return;
        
            if (onDecreaseEffect!=null)
                targetResource.OnDecreaseValue.AddListener((ctg) => onDecreaseEffect.PlayEffect(transform.position));
            if(onIncreasedEffect !=null)
                targetResource.OnIncreaseValue.AddListener((ctg) => onIncreasedEffect.PlayEffect(transform.position));
            if(onChangedEffect!=null)
                targetResource.OnValueChanged.AddListener((ctg) => onChangedEffect.PlayEffect(transform.position));
        }
    }
}
