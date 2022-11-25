using UnityEngine;

namespace Patterns
{
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    T[] assets = Resources.LoadAll<T>("");
                    instance = assets[0];
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
