using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    public Item item;
    private Image image;

    private void OnEnable()
    {
        InitialiseItem(item);
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.icon;
    }

    private void OnTransformParentChanged()
    {
        InitialiseItem(item);
    }
}
