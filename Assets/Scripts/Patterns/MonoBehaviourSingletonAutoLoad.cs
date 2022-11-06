using UnityEngine;
using UnityEngine.EventSystems;

namespace Patterns
{
    public class MonoBehaviourSingletonAutoLoad<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance != null)
                        return instance;
                    instance = Resources.FindObjectsOfTypeAll<T>()[0];

                    if (instance == null)
                    {
                        Debug.LogError($"No autoload instance in resources: {typeof(T)}");
                    }
                    else
                    {
                        instance = Instantiate(instance);
                    }
                }
                return instance;
            }
        }

        private static T instance;
    }
}
