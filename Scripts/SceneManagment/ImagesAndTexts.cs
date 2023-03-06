using System.Collections;
using System.Collections.Generic;
using DependentObjects.ScriptableObjects.LoadingScreen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SceneManagment
{
    public class ImagesAndTexts : MonoBehaviour
    {
        [SerializeField] private Image imagePlaceholder;
        [SerializeField] private TextMeshProUGUI textPlaceholder;
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private List<LoadginScreenData> loadginScreenDatas = new List<LoadginScreenData>();
        [Range(1, 5)]
        [SerializeField] private float simplePositionTime;
        [Range(0.1f , 1)]
        [SerializeField] private float positionChangeTime;

        [SerializeField] private bool resetSize = false;

        private void Awake()
        {
            canvasGroup.alpha = 0;
            SwapToNew();
        }

        private void SwapToNew()
        {
            if (loadginScreenDatas == null || loadginScreenDatas.Count == 0)
                return;
            var simpleScreenData = loadginScreenDatas[Random.Range(0, loadginScreenDatas.Count)];
            imagePlaceholder.sprite = simpleScreenData.Image;
            textPlaceholder.text = simpleScreenData.Text;
            if(resetSize)
                imagePlaceholder.SetNativeSize();
            StartCoroutine(Timer());
        }


        private IEnumerator Timer()
        {
            yield return StartCoroutine(AlphaChanger(1));
            float delta = 0;
            while (delta < 1)
            {
                delta += Time.deltaTime / simplePositionTime;
                yield return null;
            }

            yield return StartCoroutine(AlphaChanger(0));
            SwapToNew();
        }

        private IEnumerator AlphaChanger(float to)
        {
            float delta = 0;
            float from = canvasGroup.alpha;

            while (delta < 1)
            {
                delta += Time.deltaTime / positionChangeTime;
                canvasGroup.alpha = Mathf.Lerp(from, to, delta);
            
                yield return null;
            }
        }
    }
}
