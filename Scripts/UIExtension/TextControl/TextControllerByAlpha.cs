using System.Collections;
using UnityEngine;

namespace UIExtension.TextControl
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TextControllerByAlpha : TextController
    {
        [SerializeField] private float alphaInSpeed = 1;
        [SerializeField] private float alphaOutSpeed = 1;
        
        private CanvasGroup canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public override void ShowText(string text)
        {
            tmpText.text = text;
            ResetCorotines();
            StartCoroutine(ShowText());
        }

        public override void CloseText()
        {
            ResetCorotines();
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
                delta += Time.deltaTime * alphaInSpeed;
                canvasGroup.alpha = delta;
            }
        }

        private IEnumerator HideText()
        {
            float delta = 0;

            while (delta<1)
            {
                yield return null;
                delta += Time.deltaTime * alphaOutSpeed;
                canvasGroup.alpha = 1-delta;
            }
        }
    }
}
