using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PanelAnimationMove : PanelAnimationBase
{
    // Todo: Add handle EASE type
    
    [SerializeField] private Vector2 showPosition;
    [SerializeField] private Vector2 hidePosition;
    [SerializeField] private float showSpeed = 1;
    [SerializeField] private float hideSpeed = 1;
    
    private RectTransform rectTransform;

    public override void OnPanelInit()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public override void ShowAnimation(Action onComplete)
    {
        OnStatusChangedEvent(PanelAnimationStatus.ShowingAnimation);
        var pos = rectTransform.anchoredPosition;
        var tweenerCore = DOTween.To(() => pos, x => pos = x, showPosition, showSpeed);
        tweenerCore.onUpdate += () => rectTransform.anchoredPosition = pos;
        tweenerCore.onComplete += () =>
        {
            OnStatusChangedEvent(PanelAnimationStatus.Show);
            onComplete?.Invoke();
        };
    }

    public override void HideAnimation(Action onComplete)
    {
        OnStatusChangedEvent(PanelAnimationStatus.HidingAnimation);
        var pos = rectTransform.anchoredPosition;
        var tweenerCore = DOTween.To(() => pos, x => pos = x, hidePosition, hideSpeed);
        tweenerCore.onUpdate += () => rectTransform.anchoredPosition = pos;
        tweenerCore.onComplete += () =>
        {
            OnStatusChangedEvent(PanelAnimationStatus.Hide);
            onComplete?.Invoke();
        };
    }
    
    public override void SetVisible(bool visible)
    {
        rectTransform.anchoredPosition = visible ? showPosition : hidePosition;
        if(visible)
        {
            OnShow?.Invoke();
        }
        else
        {
            OnHide?.Invoke();
        }
    }
}
