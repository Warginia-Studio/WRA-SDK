using UnityEngine;

namespace Patterns
{
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.FindObjectsOfTypeAll<T>()[0];
                    if (instance == null)
                    {
                        Debug.LogError($"No scriptable instance in resources: {typeof(T)}");
                    }
                }

                return instance;
            }
        }

        private static T instance;
    }
}
