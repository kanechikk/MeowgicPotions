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
    private TextMeshProUGUI m_buttonText;

    public void FillLineBuy(Item item, string itemNameAndPrice, string itemInfo, int count, Inventory inventory, Inventory shop)
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
        m_button.onClick.AddListener(delegate { BuyItem(inventory, shop); });
    }

    public void FillLineSell(Item item, string itemNameAndPrice, string itemInfo, int count, Inventory inventory)
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
        m_button.onClick.AddListener(delegate { SellItem(inventory); });

        m_buttonText = texts[3];
        m_buttonText.text = "Sell";
    }

    public void BuyItem(Inventory inventory, Inventory shop)
    {
        ShopListUI shopListUI = GetComponent<ShopListUI>();
        if (inventory.coins >= shopListUI.Item.price)
        {
            int index = shop.GetSlotIndex(shopListUI.Item);
            inventory.AddItem(shopListUI.Item);
            inventory.AddCoins(-shopListUI.Item.price);

            shop.RemoveItem(shopListUI.Item);
            shopListUI.Count.text = $"Amount: {shop.slots[index].count}";
            if (shop.slots[index].count == 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellItem(Inventory inventory)
    {
        ShopListUI shopListUI = GetComponent<ShopListUI>();
        int index = inventory.GetSlotIndex(shopListUI.Item);
        inventory.AddCoins(shopListUI.Item.price);
        inventory.RemoveItem(shopListUI.Item);
        if (inventory.slots[index].count == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            shopListUI.Count.text = $"Amount: {inventory.slots[index].count}";
        }
    }
}
