using System.Collections.Generic;
using WRA.General.Patterns.Singletons;

namespace WRA.General.Navigation
{
    public class NavigationManager : MonoBehaviourSingletonAutoCreate<NavigationManager>
    {
        private List<NavigationObserver> navigationObservers = new List<NavigationObserver>();
    
        public void AddNavigationObserver(NavigationObserver navigationObserver)
        {
            navigationObservers.Add(navigationObserver);
        }

        public void RemoveNavigationObserver(NavigationObserver navigationObserver)
        {
            navigationObservers.Remove(navigationObserver);
        }

        public NavigationObserver[] GetNavigationObservers()
        {
            return navigationObservers.ToArray();
        }

        protected override void OnCreate()
        {
            throw new System.NotImplementedException();
        }
    }
}
