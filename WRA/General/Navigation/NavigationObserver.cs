using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WRA.General.Navigation
{
    public class NavigationObserver : MonoBehaviour
    {
        public bool IsEnabled => gameObject.activeInHierarchy;
    
        private List<string> tags;
        private void Awake()
        {
            NavigationManager.Instance.AddNavigationObserver(this);
        }
    
        private void OnDestroy()
        {
            NavigationManager.Instance.RemoveNavigationObserver(this);
        }

        public void SetTags(params string[] tags)
        {
            this.tags = tags.ToList();
        }

        public void AddTag(string tag)
        {
            tags.Add(tag);
        }

        public void RemoveTag(string tag)
        {
            tags.Remove(tag);
        }

        public bool ContainsTag(string tag)
        {
            return tags.Contains(tag);
        }
    }
}
