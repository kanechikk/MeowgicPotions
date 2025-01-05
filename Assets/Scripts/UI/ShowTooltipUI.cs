
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemDesc = "test"; //gimme data
    public TooltipUI tooltipUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipUI.ShowTooltip(itemDesc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipUI.HideTooltip();
    }
}
