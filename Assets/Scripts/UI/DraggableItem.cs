using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    private Image image;
    private TextMeshProUGUI m_countText;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;

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
        image.sprite = newItem.icon;
        m_countText.text = RefreshCount(newItem);
    }

    private string RefreshCount(Item newItem)
    {
        int count = GamePlayState.inventory.slots.Find(x => x.item == newItem).count;
        return count.ToString();
    }

    private void OnTransformParentChanged()
    {
        InitialiseItem(item);
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
