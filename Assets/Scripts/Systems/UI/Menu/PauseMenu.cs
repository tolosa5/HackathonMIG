using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Game.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject PausePanel;
        private bool _isPaused;

        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Debug.Log("escape");

                _isPaused=!_isPaused;
                if (_isPaused)
                {   
                    Pause();
                } else
                {
                    Continue();
                }
            }

        }

        public void Pause()
        {
            Debug.Log("pausa");
            PausePanel.SetActive(true);
            Time.timeScale=0;
        }

        public void Continue()
        {
            Debug.Log("continue");
            PausePanel.SetActive(false);
            Time.timeScale=1;
        }
    }   
}
