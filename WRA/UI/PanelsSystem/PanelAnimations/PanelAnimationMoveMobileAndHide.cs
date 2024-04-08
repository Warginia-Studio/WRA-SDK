using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelAnimationMoveMobileAndHide : PanelAnimationMoveMobileFix
{
    public override void ShowAnimation(Action onComplete)
    {
        gameObject.SetActive(true);
        var tweenerCore = CreateTweener(0, 1, showSpeed).OnComplete(() => onComplete?.Invoke());
    }
    
    public override void HideAnimation(Action onComplete)
    {
        var tweenerCore = CreateTweener(1, 0, hideSpeed).OnComplete(() => onComplete?.Invoke());
        tweenerCore.onComplete += () => gameObject.SetActive(false);
    }

    public override void SetVisible(bool visible)
    {
        base.SetVisible(visible);
        gameObject.SetActive(visible);
    }
}
