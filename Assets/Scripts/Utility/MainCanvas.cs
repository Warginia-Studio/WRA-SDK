using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static Transform mainCanvas;
    private void Awake()
    {
        mainCanvas = transform;
    }
}
