using System;
using Game.Inputs;
using Game.Interaction;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private PlayerInteract playerInteract;
        [SerializeField] private PlayerPickUp playerPickUp;
        
        private void Start()
        {
            playerInteract = FindAnyObjectByType<PlayerInteract>();
            playerPickUp = FindAnyObjectByType<PlayerPickUp>();
            EventsSubscription();
        }

        private void EventsSubscription()
        {
            InputManager.instance.inputSystemActions.Player.Interact.performed += ctx => playerInteract.LookForInteraction();
            InputManager.instance.inputSystemActions.Player.Grab.performed += ctx => playerPickUp.PickUp();
            InputManager.instance.inputSystemActions.Player.Grab.canceled += ctx => playerPickUp.Drop();
        }
    }
}
