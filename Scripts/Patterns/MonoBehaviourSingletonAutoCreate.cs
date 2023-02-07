using UnityEngine;

namespace WRACore.Patterns
{
    public class MonoBehaviourSingletonAutoCreate<T> : MonoBehaviour where T : MonoBehaviour
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
                    }
                }
                return instance;
            }
        }

        private static T instance;
    }
}

