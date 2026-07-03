using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public InputSystem_Actions inputSystemActions;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Enable();
    }

    private void OnDestroy()
    {
        inputSystemActions.Dispose();
    }
}
