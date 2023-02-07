using UnityEngine;
using WRACore.Patterns;
using WRACore.UIExtension.Popups;

namespace WRACore.UIExtension.Managers
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
