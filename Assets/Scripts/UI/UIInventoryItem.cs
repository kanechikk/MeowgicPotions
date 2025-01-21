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

    private void OnEnable()
    {
        InitialiseItem(item);
    }

    public override void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        m_countText.text = RefreshCount(newItem);
    }

    private string RefreshCount(Item newItem)
    {
        InventorySlot slot = WalkingState.inventory.slots.Find(x => x.item == newItem);
        int count;
        if (slot != null && slot.count > 0)
        {
            count = WalkingState.inventory.slots.Find(x => x.item == newItem).count;
            return count.ToString();
        }
        else
        {
            return null;
        }
    }
}
