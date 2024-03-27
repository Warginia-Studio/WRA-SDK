using System;
using System.Collections;
using System.Collections.Generic;
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
        SetAnchorsAndPivot(showAnchorsAndPivot);
        // base.ShowAnimation(onComplete);
    }
    
    public override void HideAnimation(Action onComplete)
    {
        SetAnchorsAndPivot(hideAnchorsAndPivot);
        // base.HideAnimation(onComplete);
    }
    
    private void SetAnchorsAndPivot(AnchorsAndPivot anchorsAndPivot)
    {
        rectTransform.anchorMin = anchorsAndPivot.min;
        rectTransform.anchorMax = anchorsAndPivot.max;
        rectTransform.pivot = anchorsAndPivot.pivot;
        // rectTransform.an
    }
}
