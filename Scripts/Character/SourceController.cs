using UnityEngine;
using UnityEngine.Events;
using Utility;
using Utility.Diagnostics;

namespace Character
{
    public abstract class SourceController : MonoBehaviour
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

        private ClampedValue sourceValue;

        protected virtual void Awake()
        {
            Init(0, 100);
        }

        public virtual float AddValue(float value)
        {
            sourceValue += value;
            float relValue = useFixedValue ? sourceValue.LastChangedFixed : value;
            OnValueChanged.Invoke(relValue);
            OnIncreaseValue.Invoke(relValue);
            return relValue;
        }
        
        public virtual float RemoveValue(float value)
        {
            sourceValue -= value;
            float relValue = useFixedValue ? sourceValue.LastChangedFixed : value;
            OnValueChanged.Invoke(relValue);
            OnDecreaseValue.Invoke(relValue);
            return relValue;
        }

        protected void Init(float min, float  max)
        {
            if (sourceValue == null)
                sourceValue = new ClampedValue(min, max);
            sourceValue.SetNewValues(min, max);
        }

        protected void InitAndRegen(float min, float max)
        {
            if (sourceValue == null)
                sourceValue = new ClampedValue(min, max);
            sourceValue.SetNewValues(min, max);
            sourceValue.Value = max;
        }
    
    }
}
