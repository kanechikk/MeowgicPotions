using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemDesc = "test";
    public TooltipUI tooltipUI;
    private Item item;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponentsInChildren<DraggableItem>().Length > 0)
        item = gameObject.GetComponentsInChildren<DraggableItem>()[0].item;
        else if (gameObject.GetComponentsInChildren<UIInventoryItem>().Length > 0)
        item = gameObject.GetComponentsInChildren<UIInventoryItem>()[0].item;
        else item = null;
        if (item != null) 
        {
            UpdateDescText();
        }
        tooltipUI.ShowTooltip(itemDesc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipUI.HideTooltip();
    }

    private void UpdateDescText()
    {
        itemDesc = $"{item.itemName}\nPrice: {item.price}";
        if (item.GetType() == typeof(Ingredient))
        {
            Ingredient temp = (Ingredient)item;
            itemDesc += "\n" + temp.ElementsToString();
        }
        else if (item.GetType() == typeof(Potion))
        {
            //etc todo
        }
    }
}
