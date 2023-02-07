using UIExtension.Managers;
using UnityEngine;
using Utility.Diagnostics;

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
                        WraDiagnostics.Log($"Not found: {typeof(T)}");
                        return instance;
                    }
                    instance = Resources.FindObjectsOfTypeAll<T>()[0];


                    if (MainCanvas.TheMainCanvas != null)
                    {
                        instance = Instantiate(instance.gameObject, MainCanvas.TheMainCanvas).GetComponent<T>();
                    }
                    else
                    {
                        instance = Instantiate(instance.gameObject).GetComponent<T>();
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
