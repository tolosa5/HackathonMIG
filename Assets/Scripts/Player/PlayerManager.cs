using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInteract playerInteract;
    
    public Action onShowTooltip;
    public Action onHideTooltip;

    private void OnEnable()
    {
        EventsSubscription();
    }

    private void EventsSubscription()
    {
        InputManager.instance.onInteractEvent += LookForInteraction;
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
