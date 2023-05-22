using System;
using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects.Profiles;
using Patterns;
using TMPro;
using UnityEditor;
using UnityEngine;
using Utility.Diagnostics;

#if UNITY_EDITOR

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

    public void ExecuteCommand()
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

#endif

