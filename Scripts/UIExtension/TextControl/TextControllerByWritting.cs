using System.Collections;
using UnityEngine;

namespace WRACore.UIExtension.TextControl
{
    public class TextControllerByWritting : TextController
    {
        // [SerializeField] private 
        public override void ShowText(string text)
        {
            throw new System.NotImplementedException();
        }

        public override void CloseText()
        {
            throw new System.NotImplementedException();
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
