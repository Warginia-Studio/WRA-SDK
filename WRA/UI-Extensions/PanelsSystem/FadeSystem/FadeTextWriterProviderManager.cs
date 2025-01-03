using UnityEngine;
using WRA.General.Patterns.Singletons;
using WRA.UI_Extensions.TextControl;

namespace WRA.UI_Extensions.PanelsSystem.FadeSystem
{
    [RequireComponent(typeof(TextControlerByWritting))]
    public class FadeTextWriterProviderManager : MonoBehaviourSingletonMustExist<FadeTextWriterProviderManager>
    {
        public TextControlerByWritting TextControlerByWritting => textControlerByWritting; 
        [SerializeField] private TextControlerByWritting textControlerByWritting;

        private void Awake()
        {
            textControlerByWritting = GetComponent<TextControlerByWritting>();
        }
    }
}
