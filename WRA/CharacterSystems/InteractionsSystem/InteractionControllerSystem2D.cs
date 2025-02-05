using UnityEngine;

namespace WRA.CharacterSystems.InteractionsSystem
{
    public class InteractionControllerSystem2D : InteractionControllerSystemBase
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer != LayerMask.NameToLayer("Interaction"))
                return;
            interactables.Add(col.GetComponent<IInteractable>());
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
                return;
            RemoveInteractables(interactables.FindIndex(ctg => ctg == other.GetComponent<IInteractable>()));
        }
    }
}
