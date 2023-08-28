using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WRA.General.Patterns;

namespace WRA.UI
{
    [RequireComponent(typeof(Image), typeof(CanvasGroup))]
    public class FadeManager : MonoBehaviourSingletonAutoLoadUI<FadeManager>
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

        public void SetFadeAlpha(float alpha)
        {
            CanvasGroup.alpha = alpha;
        }

        public void SetFadeOptions(FadeOptions fadeOptions)
        {
            this.fadeOptions = fadeOptions;
        }

        public void FadeIn()
        {
            if (ResetFading())
            {
                StartCoroutine(Fader(1, fadeOptions.FadeInTime));
            }
        }

        public void FadeOut()
        {
            if (ResetFading())
            {
                StartCoroutine(Fader(0, fadeOptions.FadeInTime));
            }
        }

        public void FadeInOut()
        {
            if (ResetFading())
            {
                StartCoroutine(FaderInOut());
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

        private IEnumerator Fader(float to, float time)
        {
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
        }
        
        private IEnumerator FaderInOut()
        {
            IsFadding = true;
            yield return Fader(1, fadeOptions.FadeInTime);
            yield return new WaitForSeconds(fadeOptions.FadeInOutWaitTime);
            IsFadding = true;
            yield return Fader(0, fadeOptions.FadeOutTime);
            IsFadding = false;
        }
    }
}
