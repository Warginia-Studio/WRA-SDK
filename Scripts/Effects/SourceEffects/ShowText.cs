using System.Collections;
using System.Collections.Generic;
using Character;
using TMPro;
using UnityEngine;

public class ShowText : OnSourceChangedEffect
{
    [SerializeField] private Color textColor;
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Vector3 spawnOffset;
    
    
    protected override void PlayEffect(float value)
    {
        if (value == 0)
            return;
        
        textMeshPro.color = textColor;
        float finalValue = Mathf.Abs(value);
        textMeshPro.text = (value < 0 ? "-" : "+") + finalValue.ToString("0");
        var text = Instantiate(textMeshPro.gameObject).transform;
        text.position = transform.position + spawnOffset;
    }
}
