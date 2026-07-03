using System;
using Game.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private PlayerInteractionController playerInteractionController;
    private CanvasManager canvasManager;

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
        canvasManager = FindObjectOfType<CanvasManager>();
    }

    public void ShowTooltip()
    {
        canvasManager.ShowTooltip();
    }

    public void HideTooltip()
    {
        canvasManager.HideTooltip();
    }
}
