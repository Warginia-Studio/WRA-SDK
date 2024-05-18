using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

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
                        WraDiagnostics.LogError($"Instance of {typeof(T)} must exist in the scene.");
                        return null;
                    }

                }
                return instance;
            }
        }

        protected static T instance;
    }
}
