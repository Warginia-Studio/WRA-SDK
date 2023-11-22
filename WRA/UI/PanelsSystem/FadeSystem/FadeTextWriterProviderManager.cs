using UnityEngine;
using WRA.General.Patterns;
using WRA.General.Patterns.Singletons;
using WRA.UI.TextControl;

namespace WRA.UI.PanelsSystem.FadeSystem
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
