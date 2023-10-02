using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.PlayerSystems.LanguageSystem;

namespace WRA.Environment
{
    public class Trigger : MonoBehaviour, IInteractable
    {
        public UnityEvent<InteractionControlerSystemBase>OnInteraction = new UnityEvent<InteractionControlerSystemBase>();

        [SerializeField] private string textTranslation;
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Interaction");
        }

        public void Interract(InteractionControlerSystemBase who)
        {
            OnInteraction.Invoke(who);
        }

        public string GetInteractionDescription()
        {
            return LanguageManager.GetTranslation(textTranslation);
        }
    }
}
