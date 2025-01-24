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
        if (GameManager.playerInventory.coins >= shop.slots[index].item.price)
        {
            GameManager.playerInventory.AddItem(shop.slots[index].item);
            GameManager.playerInventory.AddCoins(-shop.slots[index].item.price);

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
        GameManager.playerInventory.AddCoins(potionToSell.price);
        GameManager.playerInventory.RemoveItem(potionToSell);
        if (GameManager.playerInventory.slots[index].count == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            countText.transform.GetComponent<TextMeshProUGUI>().text = $"Count: {GameManager.playerInventory.slots[index].count}";
        }
    }
}
