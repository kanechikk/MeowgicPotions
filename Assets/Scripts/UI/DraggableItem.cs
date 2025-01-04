using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Ingredient item;
    private Image image;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Ingredient newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentBeforeDrag = transform.parent;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(parentAfterDrag);
        Debug.Log(parentBeforeDrag);
        Debug.Log(parentAfterDrag == parentBeforeDrag);
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
