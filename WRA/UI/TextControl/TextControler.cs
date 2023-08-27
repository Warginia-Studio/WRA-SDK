using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WRA.UI.TextControl
{
    public abstract class TextControler : MonoBehaviour
    {
        public bool IsActive => isActive;
        public bool IsWorking => isWorking;
        
        [SerializeField] protected TMP_Text tmpText;
        
        protected bool isActive = false;
        protected bool isWorking = false;
        protected List<string> waitingTexts = new List<string>();

        protected virtual void Awake()
        {
            InitVariables();
        }
    
        protected virtual void InitVariables()
        {
            if(tmpText==null)
                tmpText = GetComponent<TMP_Text>();
        }

        public abstract void ShowText(string text);

        public abstract void CloseText();
    }
}
