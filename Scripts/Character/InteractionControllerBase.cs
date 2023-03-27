using System;
using DependentObjects.Interfaces;
using DependentObjects.ScriptableObjects.Profiles;
using UnityEngine;

namespace Character
{
    public class InteractionController : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, CharacterProfile.Instance.InteractionRange);
        }
        
        public void InteractableInRange(IInteractable interactable)
        {
            
        }
    }
}
