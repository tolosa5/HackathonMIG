using UnityEngine;

namespace Game.Interaction
{
    public class SampleInteractable : BaseInteractable
    {
        public override void Interact(Transform interactor)
        {
            Debug.Log("Interacted");
        }
    }
}
