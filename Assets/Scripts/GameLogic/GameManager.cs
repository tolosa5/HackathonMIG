using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private PlayerManager playerManager;
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
        playerManager = FindObjectOfType<PlayerManager>();
        canvasManager = FindObjectOfType<CanvasManager>();

        playerManager.onShowTooltip += canvasManager.ShowTooltip;
        playerManager.onHideTooltip += canvasManager.HideTooltip;
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
