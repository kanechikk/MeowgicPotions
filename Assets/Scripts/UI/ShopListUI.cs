using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopListUI: MonoBehaviour
{
    public Item Item => m_item;
    public TextMeshProUGUI Count => m_count;
    private Item m_item;
    private Image m_image;
    private TextMeshProUGUI m_itemNameAndPrice;
    private TextMeshProUGUI m_itemInfo;
    private TextMeshProUGUI m_count;
    private Button m_button;

    public void FillLine(Item item, string itemNameAndPrice, string itemInfo, int count, Action buttonAction)
    {
        m_item = item;
        m_image = gameObject.GetComponentInChildren<Image>();
        m_image.sprite = item.icon;
        
        TextMeshProUGUI[] texts = gameObject.GetComponentsInChildren<TextMeshProUGUI>();

        m_itemNameAndPrice = texts[0];
        m_itemNameAndPrice.text = itemNameAndPrice;

        m_itemInfo = texts[1];
        m_itemInfo.text = itemInfo;

        m_count = texts[2];
        m_count.text = "Amount: " + count.ToString();

        m_button = gameObject.GetComponentInChildren<Button>();
        UnityAction unityAction = new UnityAction(buttonAction);
        m_button.onClick.AddListener(unityAction);
    }
}
