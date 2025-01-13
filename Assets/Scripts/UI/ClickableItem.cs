using System;
using NUnit.Framework.Internal.Commands;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableItem : UIItem, IPointerClickHandler
{
    public Action<Ingredient> onAddIngredient;
    public Action<Item> onAddItem;
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
    public override void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.icon;
        m_countText.text = RefreshCount(item);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        onAddIngredient?.Invoke((Ingredient)item);
        onAddItem?.Invoke(item);
        m_countText.text = RefreshCount(item);
    }
}
