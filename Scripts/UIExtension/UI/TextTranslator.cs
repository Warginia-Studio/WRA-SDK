using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility.FileManagment;

namespace UIExtension.UI
{
    public class TextTranslator : MonoBehaviour
    {
        [SerializeField] private string keyText;

        private Text text;
        private TextMeshProUGUI textMeshProUGUI;

        private void Awake()
        { 
            LanguageManager.LanguageChanged.AddListener(UpdateLang); 
            UpdateLang();
        }

        private void OnDestroy()
        {
            LanguageManager.LanguageChanged.RemoveListener(UpdateLang);
        }

        private void UpdateLang()
        {
            text = GetComponent<Text>();
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = LanguageManager.GetTransation(keyText);
            }

            if (textMeshProUGUI != null)
            {
                textMeshProUGUI.text = LanguageManager.GetTransation(keyText);
            }
        }
    }
}
