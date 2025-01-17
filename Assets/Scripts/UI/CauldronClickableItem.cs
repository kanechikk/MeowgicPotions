using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CauldronClickableItem : UIItem, IPointerClickHandler
{
    public Action<Ingredient> onRemoveIngredient;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        InitialiseItem(item);
    }
    public override void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onRemoveIngredient?.Invoke((Ingredient)item);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
