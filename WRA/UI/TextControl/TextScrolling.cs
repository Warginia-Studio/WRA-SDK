using System.Collections;
using UnityEngine;

namespace WRA.UI.TextControl
{
    public enum StartPosition
    {
        fromLeft,
        fromRight,
        fromTop,
        fromBot
    }
    public class TextScrolling : TextController
    {
        private readonly Vector3[] START_PIVOTS = new[] { new Vector3(1, 0.5f), new Vector3(0, 0.5f), new Vector3(0.5f, 0), new Vector3(0.5f, 1) };
        private readonly Vector3[] START_ANCHORS = new[] { new Vector3(0, 0.5f), new Vector3(1, 0.5f), new Vector3(0.5f, 1), new Vector3(0.5f, 0) };

        [SerializeField] private string addTextAtStartAndEnd;
        [SerializeField] private float scrollTextSpeed=1;

        [SerializeField] private StartPosition startPosition;

    
        // [SerializeField] private int repeats;
        private bool isScrolling;
        private RectTransform rectTransformOfObject;
        private RectTransform parrent;
        private RectTransform thisBase;

        protected override void Awake()
        {
            rectTransformOfObject = tmpText.GetComponent<RectTransform>();
            thisBase = GetComponent<RectTransform>();
            parrent = tmpText.transform.parent.GetComponent<RectTransform>();
        }

        private void Update()
        {
            if(isScrolling)
                return;
            if (waitingTexts.Count > 0)
            {
                StartCoroutine(ScrollText(waitingTexts[0]));
                waitingTexts.RemoveAt(0);
            }
        }


        public override void ShowText(string text)
        {
            text = addTextAtStartAndEnd + text + addTextAtStartAndEnd;
            waitingTexts.Add(text);
        }

        public override void CloseText()
        {
        
        }

        private IEnumerator ScrollText(string text)
        {
            isScrolling = true;
            tmpText.text = text;
        
            rectTransformOfObject.pivot =  START_PIVOTS[(int)startPosition];
            parrent.anchorMin =  START_ANCHORS[(int)startPosition];
            parrent.anchorMax =  START_ANCHORS[(int)startPosition];

            rectTransformOfObject.localPosition = Vector3.zero;
            parrent.anchoredPosition = Vector3.zero;
        
            float delta = 0;
        

            while (delta<1)
            {
                yield return null;
                delta += Time.deltaTime * scrollTextSpeed;
                parrent.anchorMin =
                    Vector2.Lerp(START_ANCHORS[(int)startPosition], START_PIVOTS[(int)startPosition], delta); 
                parrent.anchorMax =
                    Vector2.Lerp(START_ANCHORS[(int)startPosition], START_PIVOTS[(int)startPosition], delta);
                parrent.anchoredPosition = Vector3.zero;
                rectTransformOfObject.pivot =
                    Vector2.Lerp(START_PIVOTS[(int)startPosition], START_ANCHORS[(int)startPosition], delta);
                rectTransformOfObject.localPosition = Vector3.zero;
            }

            isScrolling = false;
        }
    }
}