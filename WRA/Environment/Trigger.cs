using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.General.Language;

namespace WRA.Environment
{
    public class Trigger : MonoBehaviour, IInteractable
    {
        public UnityEvent<InteractionControllerSystemBase>OnInteraction = new UnityEvent<InteractionControllerSystemBase>();

        [SerializeField] private string textTranslation;
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Interaction");
        }

        public void Interract(InteractionControllerSystemBase who)
        {
            OnInteraction.Invoke(who);
        }

        public string GetInteractionDescription()
        {
            return LanguageManager.GetTranslation(textTranslation);
        }
    }
}
