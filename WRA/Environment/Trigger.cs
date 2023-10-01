using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.PlayerSystems.LanguageSystem;

namespace WRA.Environment
{
    public class Trigger : MonoBehaviour, IInteractable
    {
        public UnityEvent<InteractionControlerBase>OnInteraction = new UnityEvent<InteractionControlerBase>();

        [SerializeField] private string textTranslation;
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Interaction");
        }

        public void Interract(InteractionControlerBase who)
        {
            OnInteraction.Invoke(who);
        }

        public string GetInteractionDescription()
        {
            return LanguageManager.GetTranslation(textTranslation);
        }
    }
}
