using System;
using Game.Interaction;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private Transform interactTransform;
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private float interactionSize;

        private void Update()
        {
            IInteractable interactable = GetInteractableObject();
            
            if (interactable != null && interactable.GetIsInteractable())
                GameManager.instance.ShowTooltip(interactable.GetTooltipText());
            else
                GameManager.instance.HideTooltip();
        }

        private IInteractable GetInteractableObject()
        {
            Collider[] colls = Physics.OverlapSphere(interactTransform.position, 
                interactionSize, interactableMask);

            if (colls.Length <= 0) 
                return null;
        
            return colls[0].gameObject.TryGetComponent(
                out IInteractable interactable) ? interactable : null;
        }
        
        public void LookForInteraction()
        {
            Debug.Log("Looking for interaction");
            IInteractable interactable = GetInteractableObject();
            if (!interactable.GetIsInteractable())
                return;
            
            interactable?.Interact(transform);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(interactTransform.position, 0.5f);
        }
    }
}
