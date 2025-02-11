using UnityEngine;

public class ShowSignGarden : MonoBehaviour
{
    [SerializeField] private RectTransform uiSign;
    [SerializeField] private RectTransform showPlace;
    [SerializeField] private RectTransform hidePlace;

    private void OnTriggerEnter(Collider other)
    {
        Show();
    }

    private void OnTriggerExit(Collider other)
    {
        Hide();
    }

    private void Show()
    {
        uiSign.position = showPlace.position;
        uiSign.rotation = showPlace.rotation;
    }

    private void Hide()
    {
        uiSign.position = hidePlace.position;
        uiSign.rotation = hidePlace.rotation;
    }
}
