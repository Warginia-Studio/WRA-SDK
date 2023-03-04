using MainObjects;
using UIExtension.Managers;
using UnityEngine;
using Utility.Diagnostics;

namespace Patterns
{
    public class MonoBehaviourSingletonAutoCreateUI<T> : MonoBehaviour where T : MonoBehaviour
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
                        if (MainCanvas.Instance != null)
                            instance.transform.parent = MainCanvas.Instance.transform;
                        else
                            WraDiagnostics.LogError(
                                $"You called this singleton class: {typeof(T)}, it is using MainCanvas script, please add it to MainCanvas which is choiced by yourself.");
                    }
                }
                return instance;
            }
        }

        private static T instance;
    }
}

