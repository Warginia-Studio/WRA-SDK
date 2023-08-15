using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using WRA.General;
using WRA.General.Patterns;

namespace WRA.Utility.Diagnostics
{
    public class WraConsole : MonoBehaviourSingletonAutoLoad<WraConsole>
    {
        [SerializeField] private Transform content;
        [SerializeField] private TMP_InputField inputField;
    
        [InitializeOnEnterPlayMode]
        public static void Init()
        {
            if (!ApplicationProfile.Instance.CustomConsole)
                return;
            Application.logMessageReceived += WraConsole.Instance.LogReceived;
        }

        public void ExecuteCommand(params string[] command)
        {
            WraDiagnostics.LogError($"Commands are not designed, tried to execute: {inputField.text}");
        }
        
        private void LogReceived(string logString, string stackTrace, LogType type)
        {
            GameObject g = new GameObject($"Log{DateTime.Now}");
            g.transform.parent = content;
            var tmp = g.AddComponent<TextMeshProUGUI>();

            tmp.text = logString + "\n" + stackTrace;
        }
    }
}

