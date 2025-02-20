using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    private bool m_needToRefreshInventory = true;
    private bool m_ingredients_stocked;
    private bool m_seeds_stocked;
    [SerializeField] private GameObject m_ingredientsPanel;
    [SerializeField] private GameObject m_seedsPanel;
    [SerializeField] private GameObject m_potionsPanel;
    [SerializeField] private ShopUI shopUI;

    private void Start()
    {
        GameManager.instance.shopData.inventory.onInvChange += OnInventoryChange;
    }

    private void OnInventoryChange(Item item)
    {
        m_needToRefreshInventory = true;
    }

    private void OnEnable()
    {
        if (!m_ingredients_stocked || !m_seeds_stocked)
        {
            FillTheShop();
        }
        if (m_needToRefreshInventory)
        {
            FillSellList();
            m_needToRefreshInventory = false;
        }
    }

    private void FillSellList()
    {
        List<GameObject> lines = shopUI.FillSell();
        foreach(GameObject line in lines)
        {
            line.transform.SetParent(m_potionsPanel.transform);
        }
    }

    private void FillTheShop()
    {
        List<List<GameObject>> twoLists = shopUI.FillShop();

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
