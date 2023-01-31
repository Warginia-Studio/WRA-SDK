using UnityEngine;

namespace Patterns
{
    public class MonoBehaviourSingletonMustExist<T> : MonoBehaviour where T : MonoBehaviour
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
                        Debug.LogError($"Istance of {typeof(T)} must exist in the scene.");
                        return null;
                    }

                }
                return instance;
            }
        }

        private static T instance;
    }
}
