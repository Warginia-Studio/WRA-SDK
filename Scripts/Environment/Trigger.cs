using Character.Interactions;
using DependentObjects.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Utility.FileManagment;

namespace Environment
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
            return LanguageManager.GetTransation(textTranslation);
        }
    }
}
