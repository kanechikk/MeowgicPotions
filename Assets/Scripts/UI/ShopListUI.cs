using System.Data;
using UnityEngine;

public class ShopListUI : MonoBehaviour
{
    public Inventory shop;
    public int index;
    
    public void BuyItem()
    {
        if (GamePlayState.inventory.slots[0].count >= shop.slots[index].item.price)
        {
            GamePlayState.inventory.AddItem(shop.slots[index].item);
            GamePlayState.inventory.slots[0].count -= shop.slots[index].item.price;

            ShoppingState.shop.RemoveItem(shop.slots[index].item);
            if (shop.slots[index].count == 0)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }
}
