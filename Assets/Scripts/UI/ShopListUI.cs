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
        if (GameManager.instance.player.inventory.coins >= shop.slots[index].item.price)
        {
            GameManager.instance.player.inventory.AddItem(shop.slots[index].item);
            GameManager.instance.player.inventory.AddCoins(-shop.slots[index].item.price);

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
        GameManager.instance.player.inventory.AddCoins(potionToSell.price);
        GameManager.instance.player.inventory.RemoveItem(potionToSell);
        if (GameManager.instance.player.inventory.slots[index].count == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            countText.transform.GetComponent<TextMeshProUGUI>().text = $"Count: {GameManager.instance.player.inventory.slots[index].count}";
        }
    }
}
