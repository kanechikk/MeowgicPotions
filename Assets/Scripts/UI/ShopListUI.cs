using System.Data;
using TMPro;
using UnityEngine;

public class ShopListUI : MonoBehaviour
{
    public Inventory shop;
    public int index;
    public GameObject countText;
    public Potion potionToSell;
    
    public void BuyItem()
    {
        if (WalkingState.inventory.coins >= shop.slots[index].item.price)
        {
            WalkingState.inventory.AddItem(shop.slots[index].item);
            WalkingState.inventory.AddCoins(-shop.slots[index].item.price);

            shop.RemoveItem(shop.slots[index].item);
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

    public void SellItem()
    {
        WalkingState.inventory.AddCoins(potionToSell.price);
        WalkingState.inventory.RemoveItem(potionToSell);
        if (WalkingState.inventory.slots[index].count == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            countText.transform.GetComponent<TextMeshProUGUI>().text = $"Count: {WalkingState.inventory.slots[index].count}";
        }
    }
}
