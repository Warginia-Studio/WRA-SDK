using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WRA.Utility.UI
{
    public class LoadingCircle : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private int elementsToHighlight = 3;
        
        private List<CanvasGroup> children = new List<CanvasGroup>();
        
        private int currentIndex = 0;
        private float delta = 0;
        
        private void Awake()
        {
            foreach (Transform child in transform)
            {
                if (child == transform)
                    continue;
                children.Add(child.GetComponent<CanvasGroup>());
            }
        }

        private void Update()
        {
            delta += Time.deltaTime * speed;
            if (delta >= 1)
            {
                delta = 0;
                currentIndex++;
                if (currentIndex >= children.Count)
                    currentIndex = 0;
            }

            for (int i = 0; i < children.Count; i++)
            {
                children[i].alpha = 0;
            }
            
            float alphaStep = 1f / elementsToHighlight;
            
            for (int i = 0; i < elementsToHighlight; i++)
            {
                int index = currentIndex + i;
                if (index >= children.Count)
                    index -= children.Count;
                children[index].alpha = alphaStep * i;
            }
        }
        
        private void CalculateElementsToHighlight()
        {
            
        }
    }
}
