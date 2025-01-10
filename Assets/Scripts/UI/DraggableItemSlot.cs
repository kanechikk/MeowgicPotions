using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItemSlot : MonoBehaviour, IDropHandler
{
    public event Action<Ingredient> onAddIngredient;
    public event Action<Ingredient> onReturnFromCauldron;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            if (draggableItem.parentAfterDrag.gameObject.tag != draggableItem.parentBeforeDrag.gameObject.tag && draggableItem.parentAfterDrag.gameObject.tag == "CauldronSlot")
            {
                onAddIngredient?.Invoke((Ingredient)draggableItem.item);
            }
            else if (draggableItem.parentAfterDrag.gameObject.tag != draggableItem.parentBeforeDrag.gameObject.tag && draggableItem.parentAfterDrag.gameObject.tag == "InventorySlot")
            {
                onReturnFromCauldron?.Invoke((Ingredient)draggableItem.item);
            }
            
        }
        else
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            GameObject current = transform.GetChild(0).gameObject;
            DraggableItem currentDraggable = current.GetComponent<DraggableItem>();

            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;

            onAddIngredient?.Invoke((Ingredient)draggableItem.item);
        }
    }


}
