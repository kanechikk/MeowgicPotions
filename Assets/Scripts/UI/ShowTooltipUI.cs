using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemDesc = "test";
    public TooltipUI tooltipUI;
    private Item item;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //todo: gives error, check if exists beforehand
        item = gameObject.GetComponentsInChildren<DraggableItem>()[0].item;
        if (item != null) 
        {
            Debug.Log("item found: " + item);
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
