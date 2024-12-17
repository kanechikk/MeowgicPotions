using UnityEngine;

public class BrewerManager : MonoBehaviour
{
    public GameObject bookPanel;

    private void Start()
    {
        bookPanel.SetActive(false);
    }
    public void OpenBook()
    {
        bookPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
