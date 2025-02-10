using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCreating : MonoBehaviour
{
    public GameObject CreateObject(GameObject prefab, Transform parent, Sprite sprite, string name)
    {
        GameObject newBtn = Instantiate(prefab, parent);
        newBtn.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprite;
        newBtn.name = name;

        return newBtn;
    }
}
