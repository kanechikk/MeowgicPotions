using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCreating : MonoBehaviour
{
    public void CreateObject(GameObject prefab, GameObject parent, string text)
    {
        GameObject newBtn = Instantiate(prefab, parent.transform);
        newBtn.GetComponent<TextMeshPro>().text = text;
    }
}
