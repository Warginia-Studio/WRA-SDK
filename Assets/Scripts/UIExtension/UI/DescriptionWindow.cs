using System;
using System.Collections;
using System.Collections.Generic;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionWindow : MonoBehaviourSingletonAutoLoadUI<DescriptionWindow>
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
        descriptionBackground.sizeDelta = new Vector2(DESCRIPTION_BASE_SIZE_X, 0);
        text.text = description;
        descriptionBackground.sizeDelta = new Vector2(DESCRIPTION_BASE_SIZE_X,
            LayoutUtility.GetPreferredHeight(text.rectTransform) + DESCRIPTION_BASE_SIZE_Y);
        StopAllCoroutines();
        StartCoroutine(Animate(timeIn));
    }

    public void HideDescription(float timeOut)
    {
        StopAllCoroutines();
        StartCoroutine(Animate(timeOut));
    }

    private IEnumerator Animate(float time)
    {
        float delta = 0;

        while (delta < 1)
        {
            yield return null;
            delta += Time.deltaTime / time;
            canvasGroup.alpha = delta;
        }
    }
}
