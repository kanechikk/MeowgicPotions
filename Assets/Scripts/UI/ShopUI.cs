using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    private ShopListUI shopListUI;
    [SerializeField] private GameObject shopLinePrefab;
    [SerializeField] private TextMeshProUGUI m_coins;
    [SerializeField] private AudioButton m_audioButton;

    private void Start()
    {
        GameManager.instance.player.inventory.onCoinsChange += OnCoinsChange;
    }

    private void OnCoinsChange()
    {
        m_coins.text = $"{GameManager.instance.player.inventory.coins}";

        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXCoins);
    }

    private void OnEnable()
    {
        m_coins.text = $"{GameManager.instance.player.inventory.coins}";
    }

    public List<List<GameObject>> FillShop(Inventory inventory, Inventory shop)
    {
        List<GameObject> linesIngredients = new List<GameObject>();
        List<GameObject> linesSeeds = new List<GameObject>();

        for (int i = 0; i < shop.slots.Count; i++)
        {
            if (shop.slots[i].category != ItemCategory.Nothing)
            {
                GameObject line = Instantiate(shopLinePrefab);

                shopListUI = line.GetComponent<ShopListUI>();
                
                if (shop.slots[i].item is Ingredient)
                {
                    shopListUI.FillLineBuy(shop.slots[i].item, shop.slots[i].item.itemName, shop.slots[i].item.ToStringItem(),
                    shop.slots[i].count, inventory, shop);
                    linesIngredients.Add(line);
                }
                else if (shop.slots[i].item is Seed)
                {
                    shopListUI.FillLineBuy(shop.slots[i].item, shop.slots[i].item.itemName, shop.slots[i].item.ToStringItem(),
                    shop.slots[i].count, inventory, shop);
                    linesSeeds.Add(line);
                }
            }
        }
        List<List<GameObject>> lists = new List<List<GameObject>>
        {
            linesIngredients,
            linesSeeds
        };
        return lists;
    }

    public List<GameObject> FillSell(Inventory inventory)
    {
        List<GameObject> linesPotons = new List<GameObject>();

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].category != ItemCategory.Nothing)
            {
                GameObject line = Instantiate(shopLinePrefab);

                shopListUI = line.GetComponent<ShopListUI>();

                if (inventory.slots[i].item is Potion)
                {
                    shopListUI.FillLineSell(inventory.slots[i].item, inventory.slots[i].item.itemName, inventory.slots[i].item.ToStringItem(),
                    inventory.slots[i].count, inventory);
                    linesPotons.Add(line);
                }
            }
        }
        return linesPotons;
    }
}
