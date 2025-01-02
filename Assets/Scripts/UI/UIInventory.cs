using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public Transform container;
    private Inventory m_inventory;

    private void Start()
    {
        m_inventory = GamePlayState.inventory;
        Fill(m_inventory);
    }

    //заполнение инвентаря
    private void Fill(Inventory inventory)
        {
            var child = container.GetChild(0);
            var slotPrefab = child.GetComponent<UIUserInventorySlot>();
            var slots = inventory.slots;
            
            int maxCount = Mathf.Max(slots.Count, container.childCount);

            
            for (int i = 0; i < maxCount; ++i)
            {
                InventorySlot slot = null;
                UIUserInventorySlot uiSlot = null;

                if (i < slots.Count)
                {
                    slot = slots[i];
                }

                if (i < container.childCount)
                {
                    uiSlot = container.GetChild(i).GetComponent<UIUserInventorySlot>();
                }
                else
                {
                    uiSlot = Instantiate(slotPrefab, container);
                }

                if (slot != null && uiSlot != null)
                {
                    uiSlot.SetData(slot);
                }
                
                uiSlot.gameObject.SetActive(i < slots.Count);
            }
        }




}
