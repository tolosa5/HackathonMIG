using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Interaction Tooltip")]
    [SerializeField] private GameObject tooltipWrapper;
    [SerializeField] private TextMeshProUGUI tooltipText;
    
    public void ShowTooltip()
    {
        if (tooltipWrapper.activeSelf)
            return;
        
        Debug.Log("show");
        tooltipWrapper.SetActive(true);
    }

    public void HideTooltip()
    {
        if (!tooltipWrapper.activeSelf)
            return;
        
        Debug.Log("hide");
        tooltipWrapper.SetActive(false);
    }
}
