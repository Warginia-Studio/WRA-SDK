using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class SimpleSelectionText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private CanvasGroup selection;
        [SerializeField] private TMP_Text text;
        private Action<SimpleSelectionText> onClick;
    
        public void Bind(string text, Action<SimpleSelectionText> onClick)
        {
            this.text.text = text;
            this.onClick = onClick;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            selection.alpha = 1;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selection.alpha = 0;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke(this);
        }
    }
}
