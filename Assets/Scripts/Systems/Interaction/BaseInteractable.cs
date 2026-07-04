using UnityEngine;

namespace Game.Interaction
{
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool isInteractable = true;
        [SerializeField] protected string tooltip;
        
        public abstract void Interact(Transform interactor);
        public string GetTooltipText() { return tooltip; }
        public bool GetIsInteractable() { return isInteractable; }

        public Transform GetTransform() { return transform; }
    }
}
