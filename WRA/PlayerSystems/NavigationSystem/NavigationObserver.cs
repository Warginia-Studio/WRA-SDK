using UnityEngine;

namespace WRA.PlayerSystems.NavigationSystem
{
    public class NavigationObserver : MonoBehaviour
    {
        public bool IsEnabled => gameObject.activeInHierarchy;
    
        private string[] tags;
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
            this.tags = tags;
        }

        public string[] GetTags()
        {
            return tags;
        }
    }
}
