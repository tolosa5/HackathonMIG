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
            if (GetInteractableObject() != null)
                GameManager.instance.ShowTooltip();
            else
                GameManager.instance.HideTooltip();
        }

        public IInteractable GetInteractableObject()
        {
            Collider[] colls = Physics.OverlapSphere(interactTransform.position, 
                interactionSize, interactableMask);

            if (colls.Length <= 0) 
                return null;
        
            return colls[0].gameObject.TryGetComponent(
                out IInteractable interactable) ? interactable : null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(interactTransform.position, 0.5f);
        }
    }
}
