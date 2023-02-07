using Patterns;
using UIExtension.Popups;
using UnityEngine;

namespace UIExtension.Managers
{
    public class DescriptionManager : MonoBehaviourSingletonAutoCreateUI<DescriptionManager>
    {
        [SerializeField] private DescriptionWindow descriptionWindow;

        private void Awake()
        {
            descriptionWindow = DescriptionWindow.Instance;
        }

        public void ShowDescription(string description, float timeIn = 0.2f)
        {
            descriptionWindow.ShowDescription(description, timeIn);
            
        }

        public void HideDescription(float timeOut = 0.2f)
        {
            descriptionWindow.HideDescription(timeOut);
        }
    }
}
