using System.Collections.Generic;
using UnityEngine;

public class InventoryNavigation : MonoBehaviour
{
    public void TurnInvOn(GameObject itemsInventory)
    {
        itemsInventory.SetActive(true);
        /*if (itemsInventory.transform.childCount == 0)
        {
            foreach (Item item in items)
            {
                m_buttonsCreating.CreateObject(btnPrefab, itemsInventory, item.name);
            }           
        }*/
    }
    public void TurnInvOff(GameObject itemsInventory)
    {
        itemsInventory.SetActive(false);
    }
}
