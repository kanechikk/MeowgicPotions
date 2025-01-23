using UnityEngine;

public class ShowInteractionSign : MonoBehaviour
{
    [SerializeField] private RectTransform uiSign;
    [SerializeField] private RectTransform showPlace;
    [SerializeField] private RectTransform hidePlace;

    private void OnTriggerEnter(Collider other)
    {
        uiSign.position = showPlace.position;
        uiSign.rotation = showPlace.rotation;
    }

    private void OnTriggerExit(Collider other)
    {
        uiSign.position = hidePlace.position;
        uiSign.rotation = hidePlace.rotation;
    }
}
