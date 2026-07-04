using UnityEngine;

namespace Game.Interaction
{
    public interface IInteractable
    {
        public void Interact(Transform interactor);
    }
}
