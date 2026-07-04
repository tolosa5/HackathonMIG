using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace Game.MainMenu
{
    public class MainMenuCanva : MonoBehaviour
    {
        public AudioMixer audiomixer;
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void QuitGame()
        {
            Debug.Log("se salio");
            Application.Quit();
        }

        public void SetVolume(float volume)
        {
            audiomixer.SetFloat("volume", volume);
            Debug.Log(volume);
        }

    }
}
