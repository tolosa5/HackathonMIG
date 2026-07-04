using UnityEngine;

namespace Game.Interaction
{
    public interface IInteractable
    {
        public void Interact(Transform interactor);
        public string GetTooltipText();
        public bool GetIsInteractable();
    }
}
