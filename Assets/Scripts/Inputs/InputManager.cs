using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public InputSystem_Actions inputSystemActions;

    private void Awake()
    {
        inputSystemActions = new InputSystem_Actions();
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    private void OnDestroy()
    {
        inputSystemActions.Dispose();
    }
}
