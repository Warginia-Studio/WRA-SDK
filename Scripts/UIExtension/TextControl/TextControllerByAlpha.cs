using System.Collections;
using UnityEngine;

namespace UIExtension.TextControl
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TextControllerByAlpha : TextController
    {
        private CanvasGroup canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public override void ShowText(string text)
        {
            tmpText.text = text;
            StartCoroutine(ShowText());
        }

        public override void CloseText()
        {
            StartCoroutine(HideText());
        }

        private void ResetCorotines()
        {
            StopAllCoroutines();   
        }

        private IEnumerator ShowText()
        {
            float delta = 0;
        
            while (delta<1)
            {
                yield return null;
                delta += Time.deltaTime;
                canvasGroup.alpha = delta;
            }
        }

        private IEnumerator HideText()
        {
            float delta = 0;

            while (delta<1)
            {
                yield return null;
                delta += Time.deltaTime;
                canvasGroup.alpha = 1-delta;
            }
        }
    }
}
