using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject m_ingredientsPanel;
    [SerializeField] private GameObject m_seedsPanel;
    [SerializeField] private GameObject m_potionsPanel;
    [SerializeField] private ShopUI shopUI;

    private void OnEnable()
    {
        FillTheShop();
        FillSellList();
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

    private void Erase()
    {

    }
}
