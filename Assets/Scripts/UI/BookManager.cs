using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject brewUI;

    public void CloseBook()
    {
        gameObject.SetActive(false);
        brewUI.SetActive(true);
    }
}
