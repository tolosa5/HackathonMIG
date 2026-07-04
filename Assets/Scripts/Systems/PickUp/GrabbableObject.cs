using System;
using UnityEngine;

namespace Game.Interaction
{
    public class GrabbableObject : MonoBehaviour, IGrabbable
    {
        [SerializeField] private string tooltip;
        [SerializeField] private bool isInteractable = true;
        
        private Rigidbody rb;
        private Transform grabPoint;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (!grabPoint)
                return;

            float lerpSpeed = 10f;
            Vector3 targetPosition = Vector3.Lerp(transform.position, 
                grabPoint.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(targetPosition);
        }

        public void Grab(Transform grabPoint)
        {
            this.grabPoint = grabPoint;
            rb.useGravity = false;
            Debug.Log("Grabbed");
        }

        public void Drop()
        {
            grabPoint = null;
            rb.useGravity = true;
            Debug.Log("Dropped");
        }

        public void Interact(Transform interactor)
        {
            
        }

        public string GetTooltipText() {  return tooltip; }
        public bool GetIsInteractable() {  return isInteractable; }
    }
}

