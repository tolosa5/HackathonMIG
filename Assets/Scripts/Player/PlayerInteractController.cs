using System;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    PlayerInteract playerInteract;
    PlayerPickUp playerPickUp;

    private void EventsSubscription()
    {
        InputManager.instance.inputSystemActions.Player.Interact.performed += ctx => LookForInteraction();
        InputManager.instance.inputSystemActions.Player.Grab.performed += ctx => playerPickUp.PickUp();
        InputManager.instance.inputSystemActions.Player.Grab.canceled += ctx => playerPickUp.Drop();
    }

    private void Start()
    {
        EventsSubscription();
        playerInteract = GetComponent<PlayerInteract>();
        playerPickUp = GetComponent<PlayerPickUp>();
    }

    private void LookForInteraction()
    {
        Debug.Log("Looking for interaction");
        IInteractable interactable = playerInteract.GetInteractableObject();
        interactable?.Interact(transform);
    }
}
