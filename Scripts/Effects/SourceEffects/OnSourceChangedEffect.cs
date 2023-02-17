using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using DependentObjects.Enums;
using UnityEngine;

public abstract class OnSourceChangedEffect : MonoBehaviour
{
    private readonly string[] SOURCE_CLASS_NAMES = new[] { "HealthController", "ManaController", "StaminaController", "ManaController" };
    
    [SerializeField] protected SourceType sourceType;
    private void Awake()
    {
        var v = GetComponent(SOURCE_CLASS_NAMES[(int)sourceType]) as ResourceController;
        if (v == null)
            return;
        v.OnValueChanged.AddListener(PlayEffect);
    }

    protected abstract void PlayEffect(float value);
}
