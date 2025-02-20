using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private Inventory m_shop;
    private Inventory m_inventroy;
    private ShopListUI shopListUI;
    [SerializeField] private GameObject shopLinePrefab;
    [SerializeField] private TextMeshProUGUI m_coins;

    private void Awake()
    {
        m_shop = GameManager.instance.shopData.inventory;
        m_inventroy = GameManager.instance.player.inventory;
        Debug.Log(GameManager.instance.shopData.inventory);
    }

    private void OnEnable()
    {

        m_coins.text = $"Coins: {GameManager.instance.player.inventory.coins}";
    }

    public List<List<GameObject>> FillShop()
    {
        List<GameObject> linesIngredients = new List<GameObject>();
        List<GameObject> linesSeeds = new List<GameObject>();

        for (int i = 0; i < m_shop.slots.Count; i++)
        {
            GameObject line = Instantiate(shopLinePrefab);

            shopListUI = line.GetComponent<ShopListUI>();
            
            if (m_shop.slots[i].item is Ingredient)
            {
                shopListUI.FillLine(m_shop.slots[i].item, m_shop.slots[i].item.itemName, m_shop.slots[i].item.ToStringItem(),
                m_shop.slots[i].count, BuyItem);
                linesIngredients.Add(line);
            }
            else if (m_shop.slots[i].item is Seed)
            {
                shopListUI.FillLine(m_shop.slots[i].item, m_shop.slots[i].item.itemName, m_shop.slots[i].item.ToStringItem(),
                m_shop.slots[i].count, BuyItem);
                linesSeeds.Add(line);
            }
        }
        List<List<GameObject>> lists = new List<List<GameObject>>
        {
            linesIngredients,
            linesSeeds
        };
        return lists;
    }

    public List<GameObject> FillSell()
    {

        List<GameObject> linesPotons = new List<GameObject>();

        for (int i = 0; i < m_shop.slots.Count; i++)
        {
            GameObject line = Instantiate(shopLinePrefab);

            shopListUI = line.GetComponent<ShopListUI>();

            if (m_shop.slots[i].item is Potion)
            {
                shopListUI.FillLine(m_shop.slots[i].item, m_shop.slots[i].item.itemName, m_shop.slots[i].item.ToStringItem(),
                m_shop.slots[i].count, SellItem);
                linesPotons.Add(line);
            }
        }

        return linesPotons;
    }

    public void BuyItem()
    {
        ShopListUI shopListUI = GetComponent<ShopListUI>();
        if (m_inventroy.coins >= shopListUI.Item.price)
        {
            int index = m_shop.GetSlotIndex(shopListUI.Item);
            m_inventroy.AddItem(shopListUI.Item);
            m_inventroy.AddCoins(-shopListUI.Item.price);

            m_shop.RemoveItem(shopListUI.Item);
            shopListUI.Count.text = $"Count: {m_shop.slots[index].count}";
            if (m_shop.slots[index].count == 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellItem()
    {
        ShopListUI shopListUI = GetComponent<ShopListUI>();
        int index = m_shop.GetSlotIndex(shopListUI.Item);
        m_inventroy.AddCoins(shopListUI.Item.price);
        m_inventroy.RemoveItem(shopListUI.Item);
        if (m_inventroy.slots[index].count == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            shopListUI.Count.text = $"Count: {m_inventroy.slots[index].count}";
        }
    }
}
