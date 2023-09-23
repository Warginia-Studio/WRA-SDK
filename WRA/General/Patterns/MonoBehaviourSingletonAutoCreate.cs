using UnityEngine;

namespace WRA.General.Patterns
{
    public abstract class MonoBehaviourSingletonAutoCreate<T> : MonoBehaviour where T : MonoBehaviourSingletonAutoCreate<T>
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject().AddComponent<T>();
                        instance.OnCreate();
                    }
                }
                return instance;
            }
        }
        
        private static T instance;
        
        protected abstract void OnCreate();
    }
}

