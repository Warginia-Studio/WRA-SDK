using UnityEngine;

namespace WRA.General.Patterns.Singletons
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
                        instance = new GameObject(typeof(T).Name).AddComponent<T>();
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

