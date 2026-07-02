using UnityEngine;

public class SampleInteractable : BaseInteractable
{
    public override void Interact(Transform interactor)
    {
        Debug.Log("Interacted");
    }
}
