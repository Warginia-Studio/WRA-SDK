using System.Collections;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Managers
{
    public class DescriptionManager : MonoBehaviourSingletonAutoLoad<DescriptionManager>
    {
        [SerializeField] private Transform descriptionWindow;

        public void ShowDescription(string description, float timeIn = 0.2f)
        {
            StopAllCoroutines();
            StartCoroutine(Animate(Color.white, timeIn));
        }

        public void HideDescription(float timeOut = 0.2f)
        {
            StopAllCoroutines();
            StartCoroutine(Animate(Color.clear, timeOut));
        }

        private IEnumerator Animate(Color newColor, float time)
        {
            Color currentColor = Color.white;
            float delta = 0;

            while (delta < 1)
            {
                yield return null;
                delta += Time.deltaTime / time;
            }
        }
    }
}
