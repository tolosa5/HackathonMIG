using System;
using Game.Interaction;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPickUp : MonoBehaviour
    {
        [SerializeField] private Transform grabPoint;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private float maxRayDistance = 20f;
    
        GameObject pickedGameObject;
    
        public void PickUp()
        {
            if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxRayDistance, interactableLayer))
                return;
        
            pickedGameObject = hit.collider.gameObject;
        
            if (pickedGameObject.TryGetComponent(out GrabbableObject grabbable))
                grabbable.Grab(grabPoint);
        }

        public void Drop()
        {
            if (!pickedGameObject)
                return;

            if (pickedGameObject.TryGetComponent(out GrabbableObject grabbable))
                grabbable.Drop();
        }
    }
}
