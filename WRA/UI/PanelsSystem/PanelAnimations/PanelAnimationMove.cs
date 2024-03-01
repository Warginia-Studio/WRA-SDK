using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelAnimationMove : PanelAnimationBase
{
    [SerializeField] private Vector2 showPosition;
    [SerializeField] private Vector2 hidePosition;
    [SerializeField] private float showSpeed;
    [SerializeField] private float hideSpeed;
    
    private RectTransform rectTransform;

    public override void OnPanelInit()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public override void ShowAnimation(Action onComplete)
    {
        var pos = rectTransform.anchoredPosition;
        var tweenerCore = DOTween.To(() => pos, x => pos = x, showPosition, showSpeed);
        tweenerCore.onUpdate += () => rectTransform.anchoredPosition = pos;
        tweenerCore.onComplete += () => onComplete?.Invoke();
    }

    public override void HideAnimation(Action onComplete)
    {
        var pos = rectTransform.anchoredPosition;
        var tweenerCore = DOTween.To(() => pos, x => pos = x, hidePosition, hideSpeed);
        tweenerCore.onUpdate += () => rectTransform.anchoredPosition = pos;
        tweenerCore.onComplete += () => onComplete?.Invoke();
    }
    
    public override void SetVisible(bool visible)
    {
        rectTransform.anchoredPosition = visible ? showPosition : hidePosition;
    }
}
