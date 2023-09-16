using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WRA.General.Patterns;

namespace WRA.UI
{
    [RequireComponent(typeof(Image), typeof(CanvasGroup))]
    public class FadeManager : PanelBase
    {
        public bool IsFadding { get; private set; }
        
        [SerializeField]
        private FadeOptions fadeOptions = new FadeOptions();
        
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
        
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        }
        
        public override void Open(object data)
        {
           
        }

        public override void Close(object data)
        {
            
        }

        public override void OnShow(object data)
        {
            
        }

        public override void OnHide(object data)
        {
            
        }

        public void SetFadeAlpha(float alpha)
        {
            CanvasGroup.alpha = alpha;
        }

        public void SetFadeOptions(FadeOptions fadeOptions)
        {
            this.fadeOptions = fadeOptions;
        }

        public void FadeIn(Action onEnd = null)
        {
            if (ResetFading())
            {
                StartCoroutine(Fader(1, fadeOptions.FadeInTime, onEnd));
            }
        }

        public void FadeOut(Action onEnd = null)
        {
            if (ResetFading())
            {
                StartCoroutine(Fader(0, fadeOptions.FadeInTime, onEnd));
            }
        }

        public void FadeInOut(Action onIn = null, Action onEnd = null)
        {
            if (ResetFading())
            {
                StartCoroutine(FaderInOut(onIn, onEnd));
            }
        }
        
        private bool ResetFading()
        {
            if (!fadeOptions.Force && IsFadding)
                return false;
            StopAllCoroutines();
            IsFadding = false;
            return true;
        }

        private IEnumerator Fader(float to, float time, Action onEnd)
        {
            float test = 5;
            DOTween.To(() => test, kek => test = kek, 10, 1);
            IsFadding = true;
            float delta = 0;
            float from = CanvasGroup.alpha;
            while (delta<1)
            {
                delta += Time.deltaTime * time;
                yield return null;
                CanvasGroup.alpha = Mathf.Lerp(from, to, delta);
            }
            IsFadding = false;
            onEnd?.Invoke();
        }
        
        private IEnumerator FaderInOut(Action onIn, Action onEnd)
        {
            IsFadding = true;
            yield return Fader(1, fadeOptions.FadeInTime, onIn);
            yield return new WaitForSeconds(fadeOptions.FadeInOutWaitTime);
            IsFadding = true;
            yield return Fader(0, fadeOptions.FadeOutTime, onEnd);
            IsFadding = false;
        }
    }
}
