using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    [SerializeField] private InputActionReference interactAction;
    public Action onInteractEvent;

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
    }

    private void Update()
    {
        if (interactAction.action.WasPressedThisFrame())
        {
            onInteractEvent?.Invoke();
        }
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
    }
}
