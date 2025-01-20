using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIItem : MonoBehaviour
{
    public Item item;
    public Image image;

    public virtual void InitialiseItem(Item item) {}
}
