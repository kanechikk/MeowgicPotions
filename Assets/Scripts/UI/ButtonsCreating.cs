using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCreating : MonoBehaviour
{
    public GameObject CreateObject(GameObject prefab, GameObject parent, string text)
    {
        GameObject newBtn = Instantiate(prefab, parent.transform);
        newBtn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = text;
        newBtn.name = text;

        return newBtn;
    }
}
