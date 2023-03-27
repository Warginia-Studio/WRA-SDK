using DependentObjects.Interfaces;
using UnityEngine;

namespace Character.Interactions
{
    public class InteractionController2D : InteractionControllerBase
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
