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
    public Action<Ingredient> onRemoveIngredient;
    public Action<Item> onAddItem;
    public int count = 1;
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
        image.sprite = item.icon;
        m_countText.text = RefreshCount(item);
    }

    private string RefreshCount(Item newItem)
    {
        InventorySlot slot = GameManager.playerInventory.slots.Find(x => x.item == newItem);

        if (slot != null && slot.count > 0)
        {
            count = GameManager.playerInventory.slots.Find(x => x.item == newItem).count;
            return count.ToString();
        }
        else
        {
            count = 0;
            return null;
        }
    }

    // public void Remove()
    // {
    //     Destroy(gameObject);
    // }

    public void OnPointerClick(PointerEventData eventData)
    {
        onAddIngredient?.Invoke((Ingredient)item);
        onRemoveIngredient?.Invoke((Ingredient)item);
        m_countText.text = RefreshCount(item);
        if (count == 0 || isInCauldron)
        {
            Destroy(gameObject);
            return;
        }
    }
}
