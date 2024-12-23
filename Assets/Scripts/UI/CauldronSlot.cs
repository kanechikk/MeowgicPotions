using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CauldronSlot : MonoBehaviour, IDropHandler
{
    
    public event Action<Ingredient> onAddIngredient;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            onAddIngredient?.Invoke(draggableItem.item);
        }
        else
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            GameObject current = transform.GetChild(0).gameObject;
            DraggableItem currentDraggable = current.GetComponent<DraggableItem>();

            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;

            onAddIngredient?.Invoke(draggableItem.item);
        }
    }


}
