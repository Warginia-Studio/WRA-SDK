using UnityEngine;
using UnityEngine.Events;
using Utility;
using Utility.Diagnostics;

namespace Character
{
    public abstract class SourceController : MonoBehaviour
    {
        public UnityEvent OnValueChanged = new UnityEvent();

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

        private ClampedValue sourceValue;

        protected virtual void Awake()
        {
            Init(0, 100);
        }

        public virtual void AddValue(float value)
        {
            sourceValue += value;
            OnValueChanged.Invoke();
        }
        
        public virtual void RemoveValue(float value)
        {
            sourceValue -= value;
            OnValueChanged.Invoke();
        }

        protected void Init(float min, float  max)
        {
            sourceValue = new ClampedValue(min, max);
        }
    
    }
}
