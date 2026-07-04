using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Game.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public UnityEvent GamePaused;
        public UnityEvent GameResumed;
        private bool _isPaused;

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Debug.Log("escape");
                _isPaused = !_isPaused;

                if (_isPaused)
                {
                    Time.timeScale=0;
                } 
                else
                {
                    Time.timeScale=1;    
                }
            }
        }
    }
}
