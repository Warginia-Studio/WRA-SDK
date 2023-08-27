using UnityEngine;
using WRA.General;
using WRA.General.Patterns;
using WRA.UI.TextControl;

namespace WRA.UI.Managers
{
    public class DescriptionManager : MonoBehaviourSingletonAutoLoadUI<DescriptionManager>
    {
        [SerializeField] private TextControler window;

        private TextControler spawnedTextControler;
        
        public void ShowDescription(string description)
        {
            CheckThatIsSpawned();
            spawnedTextControler.ShowText(description);
            
        }

        public void HideDescription()
        {
            CheckThatIsSpawned();
            spawnedTextControler.CloseText();
        }

        private void CheckThatIsSpawned()
        {
            if (spawnedTextControler != null)
                return;
            spawnedTextControler = Instantiate(window.gameObject, MainCanvas.Instance.transform).GetComponent<TextControler>();
        }
    }
}
