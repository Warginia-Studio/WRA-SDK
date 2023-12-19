using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;using UnityEngine.EventSystems;

public class SimpleLog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private TMP_Text text;
    private Color color;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    
    public void Bind(string text, Color color)
    {
        this.text.text = $"[ {DateTime.Now.ToShortTimeString()} ]" + text;
        this.color = color;
        this.text.color = color;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GUIUtility.systemCopyBuffer = text.text;
    }
}
