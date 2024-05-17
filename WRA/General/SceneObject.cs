using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    public static SceneObject Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }
}
