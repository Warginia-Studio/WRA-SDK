using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
        CreateTweener(0, 1, showSpeed).OnComplete(() => onComplete?.Invoke());
    }
    
    public override void HideAnimation(Action onComplete)
    {
        CreateTweener(1, 0, hideSpeed).OnComplete(() => onComplete?.Invoke());
    }

    public override void SetVisible(bool visible)
    {
        UpdateAnchors(visible ? 1 : 0);
    }
    
    protected TweenerCore<float,float,FloatOptions> CreateTweener(float from, float to, float duration, Action<float> onUpdate = null)
    {
        var tweenerCore = DOTween.To(() => from, x => from = x, to, duration);
        tweenerCore.onUpdate += () => UpdateAnchors(from);
        tweenerCore.onUpdate += () => onUpdate?.Invoke(from);
        return tweenerCore;
    }

    protected void UpdateAnchors(float delta)
    {
        rectTransform.anchorMin = Vector2.Lerp(hideAnchorsAndPivot.min, showAnchorsAndPivot.min, delta);
        rectTransform.anchorMax = Vector2.Lerp(hideAnchorsAndPivot.max, showAnchorsAndPivot.max, delta);
        rectTransform.pivot = Vector2.Lerp(hideAnchorsAndPivot.pivot, showAnchorsAndPivot.pivot, delta);
    }
}
