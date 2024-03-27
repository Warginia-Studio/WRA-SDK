using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelAnimationMoveMobileFix : PanelAnimationMove
{
    [Serializable]
    private struct AnchorsAndPivot
    {
        [SerializeField] public Vector2 min;
        [SerializeField] public Vector2 max;
        [SerializeField] public Vector2 pivot;
    }
    
    [SerializeField] private AnchorsAndPivot showAnchorsAndPivot;
    [SerializeField] private AnchorsAndPivot hideAnchorsAndPivot;

    public override void ShowAnimation(Action onComplete)
    {
        // rectTransform.pivot = showAnchorsAndPivot.pivot;
        // SetAnchorsAndPivot(showAnchorsAndPivot);
        // base.ShowAnimation(onComplete);
        float getter = 0;
        var tweenerCore = DOTween.To(() => getter, x => getter = x, 1, showSpeed);
        tweenerCore.onUpdate += () => UpdateAnchors(getter);
    }
    
    public override void HideAnimation(Action onComplete)
    {
        // rectTransform.pivot = hideAnchorsAndPivot.pivot;
        // SetAnchorsAndPivot(hideAnchorsAndPivot);
        // base.HideAnimation(onComplete);
        float getter = 1;
        var tweenerCore = DOTween.To(() => getter, x => getter = x, 0, hideSpeed);
        tweenerCore.onUpdate += () => UpdateAnchors(getter);
    }

    private void UpdateAnchors(float delta)
    {
        rectTransform.anchorMin = Vector2.Lerp(hideAnchorsAndPivot.min, showAnchorsAndPivot.min, delta);
        rectTransform.anchorMax = Vector2.Lerp(hideAnchorsAndPivot.max, showAnchorsAndPivot.max, delta);
        rectTransform.pivot = Vector2.Lerp(hideAnchorsAndPivot.pivot, showAnchorsAndPivot.pivot, delta);
    }
    
    private void SetAnchorsAndPivot(AnchorsAndPivot anchorsAndPivot)
    {
        rectTransform.anchorMin = anchorsAndPivot.min;
        rectTransform.anchorMax = anchorsAndPivot.max;
        rectTransform.pivot = anchorsAndPivot.pivot;
        // rectTransform.an
    }
}
