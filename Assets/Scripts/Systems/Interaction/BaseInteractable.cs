using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    public bool isInteractable = true;
    public abstract void Interact(Transform interactor);
    public Transform GetTransform() { return transform; }
}
