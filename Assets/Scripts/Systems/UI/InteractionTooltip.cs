using TMPro;
using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField] private GameObject tooltipWrapper;
    [SerializeField] private TextMeshProUGUI tooltipText;
    
    public void ShowTooltip(string text)
    {
        if (tooltipWrapper.activeSelf)
            return;
        
        Debug.Log("show");
        tooltipWrapper.SetActive(true);
        tooltipText.text = text;
    }

    public void HideTooltip()
    {
        if (!tooltipWrapper.activeSelf)
            return;
        
        Debug.Log("hide");
        tooltipWrapper.SetActive(false);
    }
}
