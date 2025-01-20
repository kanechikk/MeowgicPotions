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
        if (GamePlayState.inventory.coins >= shop.slots[index].item.price)
        {
            GamePlayState.inventory.AddItem(shop.slots[index].item);
            GamePlayState.inventory.AddCoins(-shop.slots[index].item.price);

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
        GamePlayState.inventory.AddCoins(potionToSell.price);
        GamePlayState.inventory.RemoveItem(potionToSell);
        if (GamePlayState.inventory.slots[index].count == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            countText.transform.GetComponent<TextMeshProUGUI>().text = $"Count: {GamePlayState.inventory.slots[index].count}";
        }
    }
}
