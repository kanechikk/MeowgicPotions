using System;
using System.Data.Common;
using NUnit.Framework.Internal.Commands;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableItem : UIItem, IPointerClickHandler
{
    public Action<Ingredient> onAddIngredient;
    public Action<Ingredient> onRemoveIngredient;
    public Action<Item> onAddItem;
    private TextMeshProUGUI m_countText;
    public bool isInCauldron = false;

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
        m_countText.text = RefreshCount(item);
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

    public void Remove()
    {
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item is Ingredient)
        {
            onAddIngredient?.Invoke((Ingredient)item);
            onRemoveIngredient?.Invoke((Ingredient)item);
        }
        else if (item is Seed)
        {
            onAddItem?.Invoke((Seed)item);
        }
        m_countText.text = RefreshCount(item);
        if (m_countText.text == null || isInCauldron)
        {
            Destroy(gameObject.transform.parent.gameObject);
            return;
        }
    }
}
