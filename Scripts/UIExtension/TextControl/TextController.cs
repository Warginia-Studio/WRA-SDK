using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UIExtension.TextControl
{
    [RequireComponent(typeof(TMP_Text))]
    public abstract class TextController : MonoBehaviour
    {
        protected TMP_Text tmpText;
        protected bool isActive = false;
        protected List<string> waitingTexts = new List<string>();

        protected virtual void Awake()
        {
            InitVariables();
        }
    
        protected virtual void InitVariables()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        public abstract void ShowText(string text);

        public abstract void CloseText();
    }
}
