using Game.EventSystem.Channels;
using Game.FirstPerson;
using Game.Inputs;
using Game.Player;
using UnityEngine;

namespace Game
{
    public class PausePlayerController : MonoBehaviour
    {
        [SerializeField] private BoolEventChannel pauseEvent;
        public GameObject Camera;
        private FirstPersonPlayerController playerController;
        // Update is called once per frame
        void Start()
        {
            pauseEvent.Register(PauseController);
        }

        private void PauseController(bool isPaused)
        {
            if (isPaused)
            {
                InputManager.instance.inputSystemActions.Player.Disable();
                InputManager.instance.inputSystemActions.UI.Enable();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Debug.Log("para");
            } 
            else
            {
                InputManager.instance.inputSystemActions.Player.Enable();
                InputManager.instance.inputSystemActions.UI.Disable();
            }
        }

        
    }
}
