using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.PlayerSystems.LanguageSystem;

namespace WRA.Environment
{
    public class Trigger : MonoBehaviour, IInteractable
    {
        public UnityEvent<InteractionControllerBase>OnInteraction = new UnityEvent<InteractionControllerBase>();

        [SerializeField] private string textTranslation;
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Interaction");
        }

        public void Interract(InteractionControllerBase who)
        {
            OnInteraction.Invoke(who);
        }

        public string GetInteractionDescription()
        {
            return LanguageManager.GetTranslation(textTranslation);
        }
    }
}
