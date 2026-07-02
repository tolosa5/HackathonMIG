using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform interactTransform;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private float interactionSize;

    public IInteractable GetInteractableObject()
    {
        Collider[] interactableColls = Physics.OverlapSphere(
            interactTransform.position, interactionSize, interactableMask);

        if (interactableColls.Length <= 0) 
            return null;
        
        return interactableColls[0].gameObject.TryGetComponent(
            out IInteractable interactable) ? interactable : null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactTransform.position, 0.5f);
    }
}
