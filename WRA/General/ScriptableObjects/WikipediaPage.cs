using UnityEngine;
using WRA.General.Enums;

namespace WRA.General.ScriptableObjects
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Wikipedia/Page", fileName = "New WikipediaPage")]
    public class WikipediaPage : ScriptableObject
    {
        public string PageTitle;
        public string[] PageTexts;
        public Sprite[] PageImages;
        public WikipediaCategories WikipediaCategories;
    }
}
