using UnityEngine;
using WRACore.DependentObjects.Enums;

namespace WRACore.DependentObjects.ScriptableObjects
{
    [CreateAssetMenu(menuName = "thief01/Wikipedia/Page", fileName = "New WikipediaPage")]
    public class WikipediaPage : ScriptableObject
    {
        public string PageTitle;
        public string[] PageTexts;
        public Sprite[] PageImages;
        public WikipediaCategories WikipediaCategories;
    }
}
