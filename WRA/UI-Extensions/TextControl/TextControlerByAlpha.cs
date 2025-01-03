using System.Collections;
using UnityEngine;

namespace WRA.UI_Extensions.TextControl
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TextControlerByAlpha : TextControler
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
            StartCoroutine(AnimateCanvasGroup(1, alphaInSpeed));
        }

        public override void CloseText()
        {
            ResetCorotines();
            StartCoroutine(AnimateCanvasGroup(0, alphaOutSpeed));
        }

        private void ResetCorotines()
        {
            StopAllCoroutines();   
        }

        private IEnumerator AnimateCanvasGroup(float targetValue, float speed)
        {
            isWorking = true;
            float delta = 0;

            while (delta<= 1 && canvasGroup.alpha != targetValue)
            {
                yield return null;
                delta += speed * Time.deltaTime;
                canvasGroup.alpha += Mathf.MoveTowards(canvasGroup.alpha, targetValue, speed * Time.deltaTime);
            }

            isWorking = false;
        }
    }
}
