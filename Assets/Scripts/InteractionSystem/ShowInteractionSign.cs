using UnityEngine;

public class ShowInteractionSign : MonoBehaviour
{
    [SerializeField] private RectTransform uiSign;
    [SerializeField] private RectTransform showPlace;
    [SerializeField] private RectTransform hidePlace;
    private Interactable m_interactable;

    private void Start()
    {
        m_interactable = gameObject.GetComponent<Interactable>();
        m_interactable.onActive += Show;
        m_interactable.onDeactive += Hide;
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
