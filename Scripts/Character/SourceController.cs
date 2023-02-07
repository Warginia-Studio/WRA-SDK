using UnityEngine;
using UnityEngine.Events;
using WRACore.Utility;
using WRACore.Utility.Diagnostics;

namespace WRACore.Character
{
    public abstract class SourceController : MonoBehaviour
    {
        public UnityEvent OnValueChanged = new UnityEvent();

        public float Value
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
        
        private ClampedValue sourceValue;
        
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
