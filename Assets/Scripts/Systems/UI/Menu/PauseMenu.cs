using UnityEngine;
using UnityEngine.InputSystem;
using Game.EventSystem.Channels;
using UnityEngine.Events;

namespace Game
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject PausePanel;
        [SerializeField] private Game.EventSystem.Channels.BoolEventChannel pauseEvent;
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
            pauseEvent.Notify(true);
        }

        public void Continue()
        {
            Debug.Log("continue");
            PausePanel.SetActive(false);
            Time.timeScale=1;
            pauseEvent.Notify(false);
        }

        public void QuitGame()
        {
            Debug.Log("se salio");
            Application.Quit();
        }
    }   
}
