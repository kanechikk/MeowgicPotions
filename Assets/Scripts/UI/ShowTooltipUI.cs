using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemDesc = "";
    [HideInInspector]
    public GameObject toolTip;
    [HideInInspector]
    public TooltipUI tooltipUI;
    public string tagOfToolTip;
    private Item m_item;

    private void Start()
    {
        toolTip = GameObject.FindGameObjectWithTag(tagOfToolTip);
        tooltipUI = toolTip.GetComponent<TooltipUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponents<UIItem>().Length > 0)
        {
            m_item = gameObject.GetComponents<UIItem>()[0].item;
            if (m_item is SampleItem)
            {
                m_item = null;
            }
        }
        else
        {
            m_item = null;
        }

        if (m_item != null)
        {
            UpdateDescText();
            tooltipUI.ShowTooltip(itemDesc);
        }
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
            itemDesc += "\n" + temp.ToStringItem();
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
