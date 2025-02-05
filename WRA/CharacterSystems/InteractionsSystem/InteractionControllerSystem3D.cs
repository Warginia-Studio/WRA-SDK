using UnityEngine;

namespace WRA.CharacterSystems.InteractionsSystem
{
    public class InteractionControllerSystem3D : InteractionControllerSystemBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
                return;
            interactables.Add(other.GetComponent<IInteractable>());
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
                return;
            RemoveInteractables(interactables.FindIndex(ctg => ctg == other.GetComponent<IInteractable>()));
        }
    }
}
