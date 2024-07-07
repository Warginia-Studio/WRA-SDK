using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace WRA.UI.PanelsSystem.PanelAnimations
{
    public class PanelAnimationMoveMobileAndHide : PanelAnimationMoveMobileFix
    {
        private TweenerCore<float, float, FloatOptions> lastTween;
    
        public override void ShowAnimation(Action onComplete)
        {
            if(lastTween!=null)
                lastTween.Kill();
            gameObject.SetActive(true);
            lastTween = CreateTweener(1, showSpeed).OnComplete(() => onComplete?.Invoke());
        }
    
        public override void HideAnimation(Action onComplete)
        {
            if(lastTween!=null)
                lastTween.Kill();
            lastTween = CreateTweener(0, hideSpeed).OnComplete(() => onComplete?.Invoke());
            lastTween.onComplete += () => gameObject.SetActive(false);
        }

        public override void SetVisible(bool visible)
        {
            base.SetVisible(visible);
            gameObject.SetActive(visible);
        }
    }
}
