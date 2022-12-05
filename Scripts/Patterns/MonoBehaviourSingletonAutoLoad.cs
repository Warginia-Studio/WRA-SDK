using UnityEngine;

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
                    //var objects = Resources.FindObjectsOfTypeAll<T>();
                    var objects = Resources.LoadAll<T>("");

                    if (objects == null || objects.Length == 0)
                    {
                        Debug.LogError($"Not found resources: {typeof(T)}");
                        return null;
                    }

                    instance = Instantiate(objects[0].gameObject).GetComponent<T>();
                }
                return instance;
            }
        }

        private static T instance;
    }
}
