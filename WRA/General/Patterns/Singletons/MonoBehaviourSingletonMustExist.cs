using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.General.Patterns.Singletons
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
                        Diagnostics.Log($"Instance of {typeof(T)} must exist in the scene.", LogType.failed);
                        return null;
                    }

                }
                return instance;
            }
        }

        protected static T instance;
    }
}
