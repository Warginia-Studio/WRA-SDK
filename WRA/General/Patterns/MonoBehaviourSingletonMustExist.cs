using UnityEngine;
using WRA.Utility.Diagnostics;

namespace WRA.General.Patterns
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

        private static T instance;
    }
}
