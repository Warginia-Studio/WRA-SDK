using System.Collections;
using UnityEngine;

namespace UIExtension.TextControl
{
    public class TextControllerByAlpha : TextController
    {
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
            }
        }

        private IEnumerator HideText()
        {
            float delta = 0;

            while (delta<1)
            {
                yield return null;
                delta += Time.deltaTime;
            }
        }
    }
}
