using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemDesc = "test";
    [HideInInspector]
    public GameObject toolTip;
    [HideInInspector]
    public TooltipUI tooltipUI;
    public string tagOfToolTip;
    private Item m_item;

    private void Start()
    {
        toolTip = GameObject.FindGameObjectWithTag(tagOfToolTip);
        Debug.Log(toolTip);
        tooltipUI = toolTip.GetComponent<TooltipUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponentsInChildren<UIItem>().Length > 0)
            m_item = gameObject.GetComponentsInChildren<UIItem>()[0].item;
        else m_item = null;
        if (m_item != null)
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
        itemDesc = $"{m_item.itemName}\nPrice: {m_item.price}";
        if (m_item.GetType() == typeof(Ingredient))
        {
            Ingredient temp = (Ingredient)m_item;
            itemDesc += "\n" + temp.ElementsToString();
        }
        else if (m_item.GetType() == typeof(Potion))
        {
            //etc todo
        }
        else if (m_item.GetType() == typeof(Seed))
        {
            //etc todo
        }
    }
}
