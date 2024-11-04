using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace WRA.UI.PanelsSystem.PanelAnimations
{
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
    
        private float delta = 0;

        public override void ShowAnimation(Action onComplete)
        {
            CreateTweener( 1, showSpeed).OnComplete(() => onComplete?.Invoke());
        }
    
        public override void HideAnimation(Action onComplete)
        {
            CreateTweener( 0, hideSpeed).OnComplete(() => onComplete?.Invoke());
        }

        public override void SetVisible(bool visible)
        {
            delta = visible ? 1 : 0;
            UpdateAnchors(delta);
        }
    
        protected TweenerCore<float,float,FloatOptions> CreateTweener(float to, float duration, Action<float> onUpdate = null)
        {
            var tweenerCore = DOTween.To(() => delta, x => delta = x, to, duration);
            tweenerCore.onUpdate += () => UpdateAnchors(delta);
            tweenerCore.onUpdate += () => onUpdate?.Invoke(delta);
            return tweenerCore;
        }

        protected void UpdateAnchors(float delta)
        {
        
            rectTransform.anchorMin = Vector2.Lerp(hideAnchorsAndPivot.min, showAnchorsAndPivot.min, delta);
            rectTransform.anchorMax = Vector2.Lerp(hideAnchorsAndPivot.max, showAnchorsAndPivot.max, delta);
            rectTransform.pivot = Vector2.Lerp(hideAnchorsAndPivot.pivot, showAnchorsAndPivot.pivot, delta);
        }
    }
}
