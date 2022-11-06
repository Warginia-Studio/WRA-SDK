using UnityEngine;
using Utility;

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
                        if (MainCanvas.mainCanvas != null)
                            instance.transform.parent = MainCanvas.mainCanvas;
                        else
                            Debug.LogError("<color=\"red\">NO MAIN CANVAS</color>");
                    }
                }
                return instance;
            }
        }

        private static T instance;
    }
}

