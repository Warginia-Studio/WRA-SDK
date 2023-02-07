using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Popups
{
    public class DescriptionWindow : PopupBase<DescriptionWindow>
    {
        private const float DESCRIPTION_BASE_SIZE_X = 400;
        private const float DESCRIPTION_BASE_SIZE_Y = 10;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private RectTransform descriptionBackground;

        private void Update()
        {
            transform.position = Input.mousePosition;
        }

        public void ShowDescription(string description, float timeIn)
        {
            Open();
            descriptionBackground.sizeDelta = new Vector2(DESCRIPTION_BASE_SIZE_X, 0);
            text.text = description;
            descriptionBackground.sizeDelta = new Vector2(DESCRIPTION_BASE_SIZE_X,
                LayoutUtility.GetPreferredHeight(text.rectTransform) + DESCRIPTION_BASE_SIZE_Y);
            StopAllCoroutines();
            StartCoroutine(Animate(timeIn, 1));
        }

        public void HideDescription(float timeOut)
        {
            Close();
            StopAllCoroutines();
            StartCoroutine(Animate(timeOut, 0));
        }

        private IEnumerator Animate(float time, float target)
        {
            float delta = 0;
            float baseAlpha = canvasGroup.alpha;

            while (delta < 1)
            {
                yield return null;
                delta += Time.deltaTime / time;
                canvasGroup.alpha = Mathf.Lerp(baseAlpha, target, delta);
            }
        }

        public override void Open()
        {
            
        }

        public override void Close()
        {
            
        }
    }
}
