using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.CharacterSystems.StatisticsSystem.Statistics;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using WRA.Utility.SmartObjects;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public abstract class ResourceSystemBaseController : Transform
    {
        [HideInInspector] public UnityEvent<float> OnValueChanged = new UnityEvent<float>();
        [HideInInspector] public UnityEvent<float> OnIncreaseValue = new UnityEvent<float>();
        [HideInInspector] public UnityEvent<float> OnDecreaseValue = new UnityEvent<float>();

        public float CurrentValue
        {
            get
            {
                if (sourceValueFloat == null)
                {
                    Diagnostics.Log($"Source value is null in: { GetType()}. You have to call Init(min, max) method. Value returned will be 0.", LogType.failed);
                    return 0;
                }

                return sourceValueFloat.Value;
            }
        }

        public float PercentValue => CurrentValue / MaxValueStatistic.Value;
        
        public DynamicStatisticValue MaxValueStatistic { get; protected set; } = new DynamicStatisticValue();

        protected StatisticsController StatisticsController;
        
        private RangedValueFloat sourceValueFloat = new RangedValueFloat(0, 100);

        protected virtual void Awake()
        {
            StatisticsController = GetCharacterSystem<StatisticsController>();
            Init(0, 100);
        }

        public virtual void AddValue(ResourcesChangedBase value)
        {
            value.RelValueChanged = value.ModifiedValue;
            sourceValueFloat += value.ModifiedValue;
            OnValueChanged.Invoke(value.RelValueChanged);
            OnIncreaseValue.Invoke(value.RelValueChanged);
        }
        
        public virtual void RemoveValue(ResourcesChangedBase value)
        {
            value.RelValueChanged = CalculateRealValueChanged(value.ModifiedValue);
            sourceValueFloat -= value.ModifiedValue;
            value.RelValueChanged = value.ModifiedValue;
            OnValueChanged.Invoke(value.RelValueChanged);
            OnDecreaseValue.Invoke(value.RelValueChanged);
        }

        protected float CalculateRealValueChanged(float change)
        {
            float previousValue = sourceValueFloat.Value;
            float currentValue = Mathf.Clamp(sourceValueFloat.Value - change, 0, MaxValueStatistic.Value);

            return Mathf.Abs(previousValue - currentValue);
        }

        protected void Init(float min, float  max)
        {
            sourceValueFloat.SetNewValues(min, max);
        }

        protected void InitAndRegen(float min, float max)
        {
            sourceValueFloat.SetNewValues(min, max);
            sourceValueFloat.Value = max;
        }
    
    }
}
