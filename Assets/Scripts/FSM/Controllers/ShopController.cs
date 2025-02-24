using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject m_ingredientsPanel;
    [SerializeField] private GameObject m_seedsPanel;
    [SerializeField] private GameObject m_potionsPanel;
    [SerializeField] private ShopUI m_shopUI;
    [SerializeField] private DayTimeManager m_dayTimeManager;
    [SerializeField] private ShoppingState shoppingState;
    private bool needToRefreshInventory = true;
    private bool seeds_stocked;
    private bool ingredients_stocked;

    private void Start()
    {
        GameManager.instance.player.inventory.onInvChange += OnInventoryChange;
        m_dayTimeManager.onDayChange += OnDayChange;
        shoppingState.onActivated += OnShoppigActive;
    }

    private void OnShoppigActive()
    {
        if (!ingredients_stocked || !seeds_stocked)
        {
            EraseBuy();
            FillTheShop();
            ingredients_stocked = true;
            seeds_stocked = true;
        }
        if (needToRefreshInventory)
        {
            EraseSell();
            FillSellList();
            needToRefreshInventory = false;
        }
    }

    private void OnDayChange()
    {
        ingredients_stocked = false;
        seeds_stocked = false;
    }

    private void OnInventoryChange(Item item)
    {
        needToRefreshInventory = true;
    }

    private void EraseSell()
    {
        Transform[] sellLists = m_potionsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < sellLists.Length; i++)
        {
            Destroy(sellLists[i].gameObject);
        }
    }

    private void EraseBuy()
    {
        Transform[] ingList = m_ingredientsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < ingList.Length; i++)
        {
            Destroy(ingList[i].gameObject);
        }

        Transform[] seedsList = m_seedsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < seedsList.Length; i++)
        {
            Destroy(seedsList[i].gameObject);
        }
    }

    private void FillSellList()
    {
        List<GameObject> lines = m_shopUI.FillSell(GameManager.instance.player.inventory);
        foreach(GameObject line in lines)
        {
            line.transform.SetParent(m_potionsPanel.transform);
        }
    }

    private void FillTheShop()
    {
        Transform[] ingsLists = m_ingredientsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < ingsLists.Length; i++)
        {
            Destroy(ingsLists[i].gameObject);
        }
        Transform[] seedsLists = m_seedsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < seedsLists.Length; i++)
        {
            Destroy(seedsLists[i].gameObject);
        }

        List<List<GameObject>> twoLists = m_shopUI.FillShop(GameManager.instance.player.inventory, GameManager.instance.shopData.inventory);

        foreach(GameObject ingLine in twoLists[0])
        {
            ingLine.transform.SetParent(m_ingredientsPanel.transform);
        }

        foreach(GameObject seedLine in twoLists[1])
        {
            seedLine.transform.SetParent(m_seedsPanel.transform);
        }
    }
}
