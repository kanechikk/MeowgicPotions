using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CauldronClickableItem : UIItem, IPointerClickHandler
{
    public Ingredient ingredient;
    public Action<Ingredient> onRemoveIngredient;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Ingredient newIngredient)
    {
        ingredient = newIngredient;
        image.sprite = ingredient.icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onRemoveIngredient?.Invoke(ingredient);
        Remove();
    }

    public void Remove()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
