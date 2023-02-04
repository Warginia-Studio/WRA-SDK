using UIExtension.Managers;
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
                    var allObjects = Resources.LoadAll<T>("");
                    
                    if (allObjects == null && allObjects.Length == 0)
                    {
                        print($"<color=\"red\">Not found: {typeof(T)}.");
                        return instance;
                    }
                    instance = Resources.FindObjectsOfTypeAll<T>()[0];


                    if (MainCanvas.mainCanvas != null)
                    {
                        instance = Instantiate(instance.gameObject, MainCanvas.mainCanvas).GetComponent<T>();
                    }
                    else
                    {
                        instance = Instantiate(instance.gameObject).GetComponent<T>();
                        Debug.LogError("<color=\"red\">NO MAIN CANVAS</color>");
                    }
                }
                return instance;
            }
        }

        private static T instance;
    }
}
