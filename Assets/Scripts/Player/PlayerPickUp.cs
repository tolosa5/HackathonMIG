using System;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private float maxRayDistance = 20f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform grabPoint;
    
    private RaycastHit[] results = new RaycastHit[5];
    private int hits = 0;
    
    public void PickUp()
    {
        hits = Physics.RaycastNonAlloc(transform.position, transform.forward, results, maxRayDistance, interactableLayer);
        if (hits <= 0)
            return;

        for (int i = 0; i < hits; i++)
        {
            if (results[i].collider.gameObject.TryGetComponent(out GrabbableObject grabbable))
                grabbable.Grab(grabPoint);
        }
    }

    public void Drop()
    {
        if (hits <= 0)
            return;

        for (int i = 0; i < hits; i++)
        {
            if (results[i].collider.gameObject.TryGetComponent(out GrabbableObject grabbable))
                grabbable.Drop();
        }
    }
    
    private void Update()
    {
        
    }
}
