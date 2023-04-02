using DependentObjects.Classes;
using DependentObjects.Classes.ResourcesInfos;
using UnityEngine;
using UnityEngine.Events;
using Utility;
using Utility.Diagnostics;

namespace Character
{
    public abstract class ResourceController : MonoBehaviour
    {
        public UnityEvent<float> OnValueChanged = new UnityEvent<float>();
        public UnityEvent<float> OnIncreaseValue = new UnityEvent<float>();
        public UnityEvent<float> OnDecreaseValue = new UnityEvent<float>();

        public float CurrentValue
        {
            get
            {
                if (sourceValue == null)
                {
                    WraDiagnostics.LogError($"Source value is null in: { GetType()}. You have to call Init(min, max) method. Value returned will be 0.");
                    return 0;
                }

                return sourceValue.Value;
            }
        }

        public abstract float PercentValue { get; }
        
        public abstract float MaxValue { get; }

        [SerializeField] private bool useFixedValue = false;

        private ClampedValue sourceValue = new ClampedValue(0, 100);

        protected virtual void Awake()
        {
            Init(0, 100);
        }

        public virtual void AddValue(ResourcesChangedBase value)
        {
            sourceValue += value.CalculatedValueChanged;
            value.RelValueChanged = useFixedValue ? sourceValue.LastChangedFixed : value.CalculatedValueChanged;
            OnValueChanged.Invoke(value.RelValueChanged);
            OnIncreaseValue.Invoke(value.RelValueChanged);
        }
        
        public virtual void RemoveValue(ResourcesChangedBase value)
        {
            sourceValue -= value.CalculatedValueChanged;
            value.RelValueChanged = useFixedValue ? sourceValue.LastChangedFixed : value.CalculatedValueChanged;
            OnValueChanged.Invoke(value.RelValueChanged);
            OnDecreaseValue.Invoke(value.RelValueChanged);
        }

        protected void Init(float min, float  max)
        {
            sourceValue.SetNewValues(min, max);
        }

        protected void InitAndRegen(float min, float max)
        {
            sourceValue.SetNewValues(min, max);
            sourceValue.Value = max;
        }
    
    }
}
