using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
    private TextMeshProUGUI m_countText;

    private void Awake()
    {
        image = GetComponent<Image>();
        m_countText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        InitialiseItem(item);
    }

    public override void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        m_countText.text = RefreshCount(newItem);
    }

    public void InitialiseItem(Item newItem, int count)
    {
        item = newItem;
        image.sprite = newItem.icon;
        m_countText.text = count.ToString();
    }

    private string RefreshCount(Item newItem)
    {
        InventorySlot slot = GameManager.instance.player.inventory.slots.Find(x => x.item == newItem);
        int count;
        if (slot != null && slot.count > 0)
        {
            count = GameManager.instance.player.inventory.slots.Find(x => x.item == newItem).count;
            return count.ToString();
        }
        else
        {
            return null;
        }
    }
}
