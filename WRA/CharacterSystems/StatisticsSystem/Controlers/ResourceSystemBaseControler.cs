using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.Utility.CustomTypes;
using WRA.Utility.Diagnostics;

namespace WRA.CharacterSystems.StatisticsSystem.Controlers
{
    public abstract class ResourceSystemBaseControler : CharacterSystemBase
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
                    WraDiagnostics.LogError($"Source value is null in: { GetType()}. You have to call Init(min, max) method. Value returned will be 0.");
                    return 0;
                }

                return sourceValueFloat.Value;
            }
        }

        public abstract float PercentValue { get; }
        
        public abstract float MaxValue { get; }
        
        private RangedValueFloat sourceValueFloat = new RangedValueFloat(0, 100);

        protected virtual void Awake()
        {
            Init(0, 100);
        }

        public virtual void AddValue(ResourcesChangedBase value)
        {
            value.RelValueChanged = value.CalculatedValueChanged;
            sourceValueFloat += value.CalculatedValueChanged;
            OnValueChanged.Invoke(value.RelValueChanged);
            OnIncreaseValue.Invoke(value.RelValueChanged);
        }
        
        public virtual void RemoveValue(ResourcesChangedBase value)
        {
            value.RelValueChanged = CalculateRealValueChanged(value.CalculatedValueChanged);
            sourceValueFloat -= value.CalculatedValueChanged;
            value.RelValueChanged = value.CalculatedValueChanged;
            OnValueChanged.Invoke(value.RelValueChanged);
            OnDecreaseValue.Invoke(value.RelValueChanged);
        }

        protected float CalculateRealValueChanged(float change)
        {
            float previousValue = sourceValueFloat.Value;
            float currentValue = Mathf.Clamp(sourceValueFloat.Value - change, 0, MaxValue);

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
