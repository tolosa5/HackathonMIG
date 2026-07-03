using System;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    PlayerInteract playerInteract;
    PlayerPickUp playerPickUp;

    private void OnEnable()
    {
        EventsSubscription();
    }

    private void EventsSubscription()
    {
        InputManager.instance.inputSystemActions.Player.Interact.performed += ctx => LookForInteraction();
        InputManager.instance.inputSystemActions.Player.Grab.performed += ctx => playerPickUp.PickUp();
        InputManager.instance.inputSystemActions.Player.Interact.canceled += ctx => playerPickUp.Drop();
    }

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void LookForInteraction()
    {
        IInteractable interactable = playerInteract.GetInteractableObject();
        interactable?.Interact(transform);
    }
}
