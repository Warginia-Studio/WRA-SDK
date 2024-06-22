using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class SimpleLog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private TMP_Text text;
        private string copyMessage;
        private Color color;
        
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color defaultColor;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }
    
        public void Bind(string text, string copyMessage)
        {
            this.text.text = text;
            this.copyMessage = copyMessage;
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            text.color = defaultColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GUIUtility.systemCopyBuffer = copyMessage;
        }
    }
}
