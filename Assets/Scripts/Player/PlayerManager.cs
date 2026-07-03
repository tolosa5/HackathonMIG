using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInteract playerInteract;
    PlayerPickUp playerPickUp;
    
    public Action onShowTooltip;
    public Action onHideTooltip;

    private void OnEnable()
    {
        EventsSubscription();
    }

    private void EventsSubscription()
    {
        InputManager.instance.onInteractEvent += LookForInteraction;
        InputManager.instance.onPickUpEvent += playerPickUp.PickUp;
        InputManager.instance.onDropEvent += playerPickUp.Drop;
    }

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void Update()
    {
        //TODO: Limpiar esto
        if (playerInteract.GetInteractableObject() != null)
            GameManager.instance.ShowTooltip();
        else
            GameManager.instance.HideTooltip();
        
    }

    private void LookForInteraction()
    {
        IInteractable interactable = playerInteract.GetInteractableObject();
        interactable?.Interact(transform);
    }
}
