using System.Collections.Generic;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.Environment;

namespace WRA.CharacterSystems.InteractionsSystem
{
    public class InteractionControlerSystemBase : CharacterSystemBase
    {
        [SerializeField] protected MapLabel mapLabel;
        protected List<IInteractable> interactables;

        protected int interactableId = 0;
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, StatisticsProfile.Instance.InteractionRange);
        }
        
        public void Interract()
        {
            if (IsEmpty())
                return;
            interactables[interactableId].Interract(this);
        }

        public void NextInteractable()
        {
            if (IsEmpty())
                return;
            interactableId++;
            if (interactables.Count-1 > 0)
                interactableId = 0;
            UpdateLabel();
        }

        public void PreviousInteractable()
        {
            if (IsEmpty())
                return;
            interactableId--;
            if (interactableId < 0)
                interactableId = interactables.Count - 1;
            UpdateLabel();
        }

        public void UpdateLabel()
        {
            if (mapLabel == null || gameObject.tag != "Player")
                return;
            var text = interactables[interactableId].GetInteractionDescription();

            if (string.IsNullOrEmpty(text))
            {
                mapLabel.CloseLabel();
                return;
            }

            mapLabel.SetLabel(interactables[interactableId].GetInteractionDescription());
        }

        protected void RemoveInteractables(int id)
        {
            PreviousInteractable();
            interactables.RemoveAt(id);
            IsEmpty();
        }

        private bool IsEmpty()
        {
            if (interactables.Count == 0)
            {
                mapLabel.CloseLabel();
                return true;
            }
            return false;
        }
    }
}
