using UnityEngine;

public interface IGrabbable : IInteractable
{
    public void Grab(Transform grabPoint);
}
