using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    public Item item;
    private Image image;

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

    private void OnEnable()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.icon;
        m_countText.text = RefreshCount(newItem);
    }

    private string RefreshCount(Item newItem)
    {
        InventorySlot slot = GamePlayState.inventory.slots.Find(x => x.item == newItem);
        int count;
        if (slot != null && slot.count > 0)
        {
            count = GamePlayState.inventory.slots.Find(x => x.item == newItem).count;
            return count.ToString();
        }
        else
        {
            return null;
        }
    }
}
