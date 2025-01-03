using UnityEngine;
using UnityEngine.Serialization;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.General.Effects;

namespace WRA.CharacterSystems.StatisticsSystem
{
    public class ResourceEffect : MonoBehaviour
    {
        [FormerlySerializedAs("targetResourceBase")] [FormerlySerializedAs("targetResource")] [SerializeField] private ResourceSystemBaseController targetResourceSystemBase;
    
        [SerializeField] protected EffectBehaviourBase onIncreasedEffect;
        [SerializeField] protected EffectBehaviourBase onDecreaseEffect;
        [SerializeField] protected EffectBehaviourBase onChangedEffect;
    
        protected virtual void Awake()
        {
            if (targetResourceSystemBase == null)
                return;
        
            if (onDecreaseEffect!=null)
                targetResourceSystemBase.OnDecreaseValue.AddListener((ctg) => onDecreaseEffect.PlayEffect(transform.position));
            if(onIncreasedEffect !=null)
                targetResourceSystemBase.OnIncreaseValue.AddListener((ctg) => onIncreasedEffect.PlayEffect(transform.position));
            if(onChangedEffect!=null)
                targetResourceSystemBase.OnValueChanged.AddListener((ctg) => onChangedEffect.PlayEffect(transform.position));
        }
    }
}
