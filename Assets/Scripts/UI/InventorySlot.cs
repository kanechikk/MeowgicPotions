using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droped = eventData.pointerDrag;
        DraggableItem draggableItem = droped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
    }
}
