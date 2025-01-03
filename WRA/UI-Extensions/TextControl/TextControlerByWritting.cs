using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace WRA.UI_Extensions.TextControl
{
    public class TextControlerByWritting : TextControler
    {
        public UnityEvent OnChangeTextTick = new UnityEvent();
        
        [SerializeField] private int writeLenghtPerTick = 1;
        [SerializeField] private int oneTickAfterFrames = 1;
        [SerializeField] private bool removeFromStart = false;

        private string textToWrite = "";
        private int countOfLetters = 0;
        private bool isRemoving = false;
        

        public override void ShowText(string text)
        {
            tmpText.text = "";
            Reset();
            textToWrite = text;
            StartCoroutine(AnimateText(1));
        }

        public override void CloseText()
        {
            Reset();
            isRemoving = true;
            StartCoroutine(AnimateText(-1));
        }
    
        private IEnumerator AnimateText(int modifier)
        {
            isWorking = true;
            while (textToWrite.Length != tmpText.text.Length)
            {
                yield return WaitForEndFrames(oneTickAfterFrames);
                countOfLetters += modifier * writeLenghtPerTick;
                UpdateText();
            }

            isWorking = false;
        }
        
        private IEnumerator WaitForEndFrames(int frames)
        {
            for (int i = 0; i < frames; i++)
            {
                yield return null;
            }
        }

        private void Reset()
        {
            StopAllCoroutines();
            countOfLetters = 0;
            isRemoving = false;
        }

        private void UpdateText()
        {
            if (countOfLetters > 0 && countOfLetters > textToWrite.Length)
            {
                countOfLetters = textToWrite.Length - 1;
            }

            if (countOfLetters < 0)
            {
                countOfLetters = 0;
            }
            
            var startIndex = 0;
            var maxIndex = countOfLetters;
            if (removeFromStart && isRemoving)
            {
                startIndex = textToWrite.Length - countOfLetters;
                maxIndex = textToWrite.Length - startIndex;
            }

            tmpText.text = textToWrite.Substring(startIndex, maxIndex);
        }
    }
}
