using System;
using System.Linq;
using UnityEngine;

public class InventoryState : MonoBehaviour
{
    public GameObject inventoryUI;

    private void OnEnable()
    {
        inventoryUI.SetActive(true);
    }


    private void OnDisable()
    {
        if (inventoryUI)
        {
            inventoryUI.SetActive(false);
        }
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }
}