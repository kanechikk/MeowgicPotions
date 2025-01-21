using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameStateBehaviour stateOfInteractable;
    [SerializeField] private RectTransform uiSign;
    [SerializeField] private RectTransform showPlace;
    [SerializeField] private RectTransform hidePlace;
    [SerializeField] private GameMode m_gameMode;
    private bool active = false;
    
    private void OnTriggerEnter(Collider other)
    {
        active = true;
        uiSign.position = showPlace.position;
        uiSign.rotation = showPlace.rotation;
        Debug.Log("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
        uiSign.position = hidePlace.position;
        uiSign.rotation = hidePlace.rotation;
        Debug.Log("Exit");
    }

    private void Update()
    {
        if (active && Keyboard.current.eKey.wasPressedThisFrame && stateOfInteractable != null)
        {
            m_gameMode.GoToState(stateOfInteractable);
        }
    }
}
