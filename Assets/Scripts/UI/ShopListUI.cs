using System.Data;
using UnityEngine;

public class ShopListUI : MonoBehaviour
{
    public Item item;
    
    public void BuyItem()
    {
        if (WalkingState.inventory.slots[0].count >= item.price)
        {
            WalkingState.inventory.AddItem(item);
            WalkingState.inventory.slots[0].count -= item.price;
        }
        else
        {
            Debug.Log("Not enough coins");
        }
        ShoppingState.shop.RemoveItem(item);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
