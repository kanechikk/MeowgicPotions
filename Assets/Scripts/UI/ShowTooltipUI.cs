
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemDesc = "test"; //gimme data

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipUI.ShowTooltip(itemDesc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI.HideTooltip();
    }
}
