using System.Data;
using TMPro;
using UnityEngine;

public class ShopListUI : MonoBehaviour
{
    public Inventory shop;
    public int index;
    public GameObject countText;
    
    public void BuyItem()
    {
        if (GamePlayState.inventory.slots[0].count >= shop.slots[index].item.price)
        {
            GamePlayState.inventory.AddItem(shop.slots[index].item);
            GamePlayState.inventory.slots[0].count -= shop.slots[index].item.price;

            ShoppingState.shop.RemoveItem(shop.slots[index].item);
            countText.transform.GetComponent<TextMeshProUGUI>().text = $"Count: {shop.slots[index].count}";
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
