using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PanelAnimationMove : PanelAnimationBase
{
    // Todo: Add handle EASE type
    
    [SerializeField] protected Vector2 showPosition;
    [SerializeField] protected Vector2 hidePosition;
    [SerializeField] protected float showSpeed = 1;
    [SerializeField] protected float hideSpeed = 1;
    
    protected RectTransform rectTransform;
    
    public override void OnFragmentInit()
    {
        rectTransform = GetComponent<RectTransform>();
        base.OnFragmentInit();
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
