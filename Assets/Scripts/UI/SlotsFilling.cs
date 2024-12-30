using UnityEngine;

public class SlotsFilling : MonoBehaviour
{
    public GameObject FillSlot(GameObject prefab, Transform parent)
    {
        GameObject newItemObject = Instantiate(prefab, parent);

        return newItemObject;
    }
}
