using TMPro;
using UnityEngine;

namespace WRA.PlayerSystems.LanguageSystem
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextTranslator : MonoBehaviour
    {
        [SerializeField] private string textKey;
        
        private TMP_Text tmpText;

        private void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
            RegisterEvents();
            UpdateLang();
        }

        private void OnDestroy()
        {
            UnRegisterEvents();
        }
        
        private void RegisterEvents()
        {
            LanguageManager.LanguageChanged.AddListener(UpdateLang); 
        }

        private void UnRegisterEvents()
        {
            LanguageManager.LanguageChanged.RemoveListener(UpdateLang);
        }

        public void SetTextKey(string textKey)
        {
            this.textKey = textKey;
        }

        protected virtual void UpdateLang()
        {
            tmpText.text = LanguageManager.GetTranslation(textKey);
        }
    }
}
