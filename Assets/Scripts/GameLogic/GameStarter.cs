using System;
using Game.EventSystem.Channels;
using Game.Inputs;
using TMPro;
using UnityEngine;
using Void = Game.EventSystem.Channels.Void;

namespace Game.Logic
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject gameStartWrapper;
        [SerializeField] private TextMeshProUGUI gameStartText;
        
        [TextArea]
        [SerializeField] private string text;
        
        [SerializeField] private VoidEventChannel onGameStartChannel;

        private void Start()
        {
            ShowStartText();
        }

        private void ShowStartText()
        {
            InputManager.instance.inputSystemActions.Player.Disable();
            InputManager.instance.inputSystemActions.UI.Enable();
            gameStartWrapper.SetActive(true);
            gameStartText.text = text;
        }

        public void HideStartText()
        {
            gameStartWrapper.SetActive(false);
            onGameStartChannel.Notify();
            InputManager.instance.inputSystemActions.UI.Disable();
            InputManager.instance.inputSystemActions.Player.Enable();
        }
    }
}
