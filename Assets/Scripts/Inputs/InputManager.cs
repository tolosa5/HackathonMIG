using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    [SerializeField] private InputActionReference interactAction;
    public Action onInteractEvent;

    [SerializeField] private InputActionReference pickUpAction;
    public Action onPickUpEvent;
    public Action onDropEvent;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void OnEnable()
    {
        interactAction.action.Enable();
        pickUpAction.action.Enable();
    }

    private void Update()
    {
        if (interactAction.action.WasPressedThisFrame())
            onInteractEvent?.Invoke();

        if (pickUpAction.action.WasPressedThisFrame())
            onPickUpEvent?.Invoke();
        if (pickUpAction.action.WasReleasedThisFrame())
            onDropEvent?.Invoke();
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
        pickUpAction.action.Disable();
    }
}
