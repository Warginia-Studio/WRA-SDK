using MainObjects;
using Patterns;
using UIExtension.TextControl;
using UnityEngine;

namespace UIExtension.Managers
{
    public class DescriptionManager : MonoBehaviourSingletonAutoLoadUI<DescriptionManager>
    {
        [SerializeField] private TextController window;

        private TextController spawnedTextController;
        
        public void ShowDescription(string description)
        {
            CheckThatIsSpawned();
            spawnedTextController.ShowText(description);
            
        }

        public void HideDescription()
        {
            CheckThatIsSpawned();
            spawnedTextController.CloseText();
        }

        private void CheckThatIsSpawned()
        {
            if (spawnedTextController != null)
                return;
            spawnedTextController = Instantiate(window.gameObject, MainCanvas.Instance.transform).GetComponent<TextController>();
        }
    }
}
