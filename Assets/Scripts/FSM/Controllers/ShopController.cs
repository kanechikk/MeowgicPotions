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
    private bool needToRefreshInventory;
    private bool seeds_stocked;
    private bool ingredients_stocked;

    private void Start()
    {
        GameManager.instance.shopData.inventory.onInvChange += OnInventoryChange;
        m_dayTimeManager.onDayChange += OnDayChange;
    }

    private void OnDayChange()
    {
        ingredients_stocked = false;
        seeds_stocked = false;
    }

    private void OnInventoryChange(Item item)
    {
        needToRefreshInventory = true;
        Debug.Log(needToRefreshInventory);
    }

    private void OnEnable()
    {
        if (!ingredients_stocked || !seeds_stocked)
        {
            FillTheShop();
        }
        if (needToRefreshInventory)
        {
            FillSellList();
            needToRefreshInventory = false;
        }
    }
    private void OnDisable()
    {
        if (needToRefreshInventory)
        {
            Transform[] sellLists = m_potionsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
            for (int i = 0; i < sellLists.Length; i++)
            {
                Destroy(sellLists[i].gameObject);
            }
        }
    }

    private void FillSellList()
    {
        List<GameObject> lines = m_shopUI.FillSell();
        foreach(GameObject line in lines)
        {
            line.transform.SetParent(m_potionsPanel.transform);
        }
    }

    private void FillTheShop()
    {
        List<List<GameObject>> twoLists = m_shopUI.FillShop();

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
