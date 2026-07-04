using System;
using Game.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private PlayerInteractionController playerInteractionController;
    private InteractionTooltip interactionTooltip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        playerInteractionController = FindObjectOfType<PlayerInteractionController>();
        interactionTooltip = FindObjectOfType<InteractionTooltip>();
    }

    public void ShowTooltip(string text)
    {
        interactionTooltip.ShowTooltip(text);
    }

    public void HideTooltip()
    {
        interactionTooltip.HideTooltip();
    }
}
