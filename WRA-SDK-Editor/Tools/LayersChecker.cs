#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.Tools.Editor
{
    public class LayersChecker 
    {
        [MenuItem("thief01/Tests/Tag Manager test")]
        public static void TagManagerTest()
        {
            Diagnostics.Log("Test isn't added yet.", LogType.error);
        }
    }
}

#endif