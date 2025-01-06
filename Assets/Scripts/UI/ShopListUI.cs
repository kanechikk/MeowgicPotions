using System.Data;
using UnityEngine;

public class ShopListUI : MonoBehaviour
{
    public Item item;
    
    public void BuyItem()
    {
        if (GamePlayState.inventory.slots[0].count >= item.price)
        {
            GamePlayState.inventory.AddItem(item);
            GamePlayState.inventory.slots[0].count -= item.price;
        }
        else
        {
            Debug.Log("Not enough coins");
        }
        ShoppingState.shop.RemoveItem(item);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
