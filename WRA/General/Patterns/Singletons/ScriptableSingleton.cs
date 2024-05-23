using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.General.Patterns.Singletons
{
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        public static T Instance
        {
            get
            {
                T[] assets = Resources.LoadAll<T>("");
                if (valueOfIstances != assets.Length)
                {
                    valueOfIstances = assets.Length;
                    instance = null;
                }
                if (instance == null)
                {
                    assets = Resources.LoadAll<T>("Resources/CustomProfiles");
                    if (assets == null || assets.Length == 0)
                    {
                        assets = Resources.LoadAll<T>("");
                    }
                    instance = assets[0];
                    if (instance == null)
                    {
                        Diagnostics.Log($"No scriptable instance in resources: {typeof(T)}", LogType.failed);
                    }
                }

                return instance;
            }
        }

        private static T instance;
        private static int valueOfIstances = 0;
    }
}
