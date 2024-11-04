using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WRA.General;
using Zenject;

namespace WRA.ThemeSystem
{
    public class ThemeFont : MonoBehaviour
    {
        [SerializeField] private string fontCategory = "default";
        [Inject] private ApplicationProfile applicationProfile;
        
        private void Awake()
        {
            var fontData = applicationProfile.fonts.Find(ctg => ctg.name == fontCategory);
            var text = GetComponent<Text>();
            if (text != null)
            {
                text.font = fontData.defaultFont;
            }
            var tmp = GetComponent<TMP_Text>();
            if (tmp != null)
            {
                tmp.font = fontData.tmpFont;
            }
        }
    }
}
