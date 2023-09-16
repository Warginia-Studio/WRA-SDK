using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.General.Patterns;

public class CinematicCameraManager : MonoBehaviourSingletonAutoLoad<CinematicCameraManager>
{
    [System.Serializable]
    private struct Curtain
    {
        public RectTransform curtain;
        public Vector3 showPosition;
        public Vector3 hidePosition;

        public void UpdatePositionByDelta(float delta)
        {
            curtain.anchoredPosition = Vector3.Lerp(hidePosition, showPosition, delta);
        }
    }

    [SerializeField] private Curtain[] curtains;


    private float currentDelta = 0;
    
    public void ShowCurtains()
    {
        StopAllCoroutines();
        StartCoroutine(Animation( 1));
    }

    public void HideCurtains()
    {
        StopAllCoroutines();
        StartCoroutine(Animation( 0));
    }
    
    private IEnumerator Animation(float to)
    {
        float localDelta = 0;
        
        while (localDelta<1 && currentDelta!=to)
        {
            localDelta += Time.deltaTime;
            currentDelta = Mathf.MoveTowards(currentDelta, to, 1 * Time.deltaTime);
            for (int i = 0; i < curtains.Length; i++)
            {
                curtains[i].UpdatePositionByDelta(currentDelta);
            }
            yield return null;
        }
    }

    protected override void OnLoad()
    {
        throw new NotImplementedException();
    }
}
