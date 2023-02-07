using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using WRACore.UIExtension.Managers;


[CustomEditor(typeof(WindowManager))]
public class WindowManagerEditor : Editor
{
    private void OnEnable()
    {
        WindowManager.Instance.FindAllWindows();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Update windows"))
        {
            WindowManager.Instance.FindAllWindows();
        }
    }
}
