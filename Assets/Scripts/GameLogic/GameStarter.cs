using System;
using Game.Inputs;
using TMPro;
using UnityEngine;

namespace Game.Logic
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject gameStartWrapper;
        [SerializeField] private TextMeshProUGUI gameStartText;
        
        [TextArea]
        [SerializeField] private string text;
        
        public Action onGameStartEvent;

        public void ShowStartText()
        {
            InputManager.instance.inputSystemActions.Player.Disable();
            InputManager.instance.inputSystemActions.UI.Enable();
            gameStartWrapper.SetActive(true);
            gameStartText.text = text;
        }

        public void HideStartText()
        {
            gameStartWrapper.SetActive(false);
            onGameStartEvent?.Invoke();
            InputManager.instance.inputSystemActions.UI.Disable();
            InputManager.instance.inputSystemActions.Player.Enable();
        }
    }
}
