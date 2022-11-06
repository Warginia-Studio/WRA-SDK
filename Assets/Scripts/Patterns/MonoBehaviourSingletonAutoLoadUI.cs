using UnityEngine;
using Utility;

namespace Patterns
{
    public class MonoBehaviourSingletonAutoLoadUI<T> : MonoBehaviour where T : MonoBehaviour
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
                    var allObjects = Resources.FindObjectsOfTypeAll<T>();
                    if (allObjects.Length == 0)
                    {
                        print($"<color=\"red\">Not found: {typeof(T)}.");
                        return instance;
                    }
                    instance = Resources.FindObjectsOfTypeAll<T>()[0];

                    if (instance == null)
                    {
                        Debug.LogError($"No autoload instance in resources: {typeof(T)}");
                    }
                    else
                    {
                        instance = Instantiate(instance);
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
