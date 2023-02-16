using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIExtension.TextControl
{
    public class TextControllerByWritting : TextController
    {
        public UnityEvent OnChangeTextTick = new UnityEvent();
        
        [SerializeField] private int writeLenghtPerTick = 1;
        [SerializeField] private int oneTickAfterFrames = 1;
        [SerializeField] private bool removeFromStart = false;

        private string textToWrite = "";

        public override void ShowText(string text)
        {
            textToWrite = text;
            StartCoroutine(WriteText());
        }

        public override void CloseText()
        {
            StartCoroutine(HideText());
        }
    
        private IEnumerator WriteText()
        {
            int frames = 0;

            while (textToWrite.Length < tmpText.text.Length)
            {
                if (frames > oneTickAfterFrames)
                {
                    WriteLetters();
                    frames = 0;
                }
                yield return null;
                frames++;
            }
        }

        private void WriteLetters()
        {
            var maxIndex = tmpText.text.Length + writeLenghtPerTick;
            if (maxIndex > tmpText.text.Length)
                maxIndex = tmpText.text.Length;
            tmpText.text = textToWrite.Substring(0, maxIndex);
            OnChangeTextTick.Invoke();
        }

        private IEnumerator HideText()
        {
            int frames = 0;

            while (textToWrite.Length < tmpText.text.Length)
            {
                if (frames > oneTickAfterFrames)
                {
                    SubText();
                    frames = 0;
                }
                yield return null;
                frames++;
            }
        }

        private void SubText()
        {
            var startIndex = removeFromStart ? 0 : tmpText.text.Length - writeLenghtPerTick;
            tmpText.text = tmpText.text.Substring(startIndex, writeLenghtPerTick);
            OnChangeTextTick.Invoke();
        }
    }
}
