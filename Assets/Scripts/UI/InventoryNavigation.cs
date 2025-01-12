using System.Collections.Generic;
using UnityEngine;

public class InventoryNavigation : MonoBehaviour
{
    public void TurnInvOn(GameObject itemsInventory)
    {
        itemsInventory.SetActive(true);
    }
    public void TurnInvOff(GameObject itemsInventory)
    {
        itemsInventory.SetActive(false);
    }
}
