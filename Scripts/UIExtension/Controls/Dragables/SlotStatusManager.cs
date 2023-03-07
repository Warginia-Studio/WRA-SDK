using System;
using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SlotStatusManager : MonoBehaviour
{
    private Image image;
    private RectTransform rectTransform;
    private void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetStatus(Vector3 position, Vector2 size, DragDropProfile.Status status)
    {
        rectTransform.position = position;
        rectTransform.sizeDelta = size;
        image.color = DragDropProfile.Instance.GetFinalColorOfDropStatus(status);
    }
}
