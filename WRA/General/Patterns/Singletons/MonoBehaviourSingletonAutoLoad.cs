using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.General.Patterns.Singletons
{
    public abstract class MonoBehaviourSingletonAutoLoad<T> : MonoBehaviour where T : MonoBehaviourSingletonAutoLoad<T>
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
                        Diagnostics.Log($"Not found resources: {typeof(T)}", LogType.failed);
                        return null;
                    }

                    instance = Instantiate(objects[0].gameObject).GetComponent<T>();
                    instance.OnLoad();
                }
                return instance;
            }
        }

        private static T instance;

        protected abstract void OnLoad();
    }
}
