using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    public Item item;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
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
        image.sprite = item.icon;
    }
}
