#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.Tools.Editor
{
    public class LayersChecker 
    {
        [MenuItem("thief01/Tests/Tag Manager test")]
        public static void TagManagerTest()
        {
            WraDiagnostics.LogError("Test isn't added yet.", Color.red);
        }
    }
}

#endif