using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class SimpleLog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public LogData LogData => logData;
        private TMP_Text text;
        private string copyMessage;
        private Color color;
        
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color defaultColor;
        
        private LogData logData;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }
    
        public void Bind(LogData logData)
        {
            this.logData = logData;
            text.text = logData.GetFinalMessage();
        }
        
        public void Refresh()
        {
            text.text = logData.GetFinalMessage();
            transform.SetAsLastSibling();
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
