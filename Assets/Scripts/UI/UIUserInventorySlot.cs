using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUserInventorySlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text count;


    public void SetData(InventorySlot slot)
    {
        count.text = slot.count.ToString();
        count.gameObject.SetActive(slot.count != 0);
    }
}

