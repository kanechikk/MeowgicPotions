using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCreating : MonoBehaviour
{
    public GameObject CreateObject(GameObject prefab, Transform parent, string text)
    {
        GameObject newBtn = Instantiate(prefab, parent);
        newBtn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = text;
        newBtn.name = text;

        return newBtn;
    }
}
