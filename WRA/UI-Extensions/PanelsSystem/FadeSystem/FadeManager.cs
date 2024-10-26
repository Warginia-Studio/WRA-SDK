using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WRA.UI.PanelsSystem.FadeSystem
{
    [RequireComponent(typeof(Image), typeof(CanvasGroup))]
    public class FadeManager : PanelBase
    {
        public bool IsFadding { get; private set; }
        
        [SerializeField] private FadeOptions fadeOptions = new FadeOptions();
        
        private CanvasGroup CanvasGroup
        {
            get
            {
                if (canvasGroup == null)
                {
                    canvasGroup = GetComponent<CanvasGroup>();
                }

                return canvasGroup;
            }
        }
        private CanvasGroup canvasGroup;
        private RectTransform rectTransform;
        private TweenerCore<float, float, FloatOptions> tweeningCoreFade;
        private float delta;
        
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        }

        public void SetFadeAlpha(float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            delta = alpha;
            UpdateFadescreen();
        }

        public void SetFadeOptions(FadeOptions fadeOptions)
        {
            this.fadeOptions = fadeOptions;
        }

        public void FadeIn(Action onEnd = null)
        {
            FadeCore(onEnd, 1, fadeOptions.FadeInTime);
            
        }

        public void FadeOut(Action onEnd = null)
        {
            FadeCore(onEnd, 0, fadeOptions.FadeOutTime);
        }

        private void FadeCore(Action onEnd, float endValue, float fadeTime)
        {
            if (fadeOptions.Force)
            {
                IsFadding = false;
                tweeningCoreFade?.Kill();
            }

            if (IsFadding)
            {
                return;
            }

            tweeningCoreFade = DOTween.To(() => delta, timer => delta = timer, endValue, fadeTime);
            if (onEnd != null)
                tweeningCoreFade.onComplete += onEnd.Invoke;
            tweeningCoreFade.onUpdate += UpdateFadescreen;
        }

        private void UpdateFadescreen()
        {
            CanvasGroup.alpha = delta;
            transform.SetAsLastSibling();
        }
        
        private bool ResetFading()
        {
            if (!fadeOptions.Force && IsFadding)
                return false;
            StopAllCoroutines();
            IsFadding = false;
            return true;
        }
    }
}
