using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameStateBehaviour m_stateOfInteractable;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private GameObject m_uiSign;
    private bool active = false;
    private void OnTriggerEnter(Collider other)
    {
        active = true;
        m_uiSign.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
        m_uiSign.SetActive(false);
    }

    private void Update()
    {
        if (active && Keyboard.current.eKey.wasPressedThisFrame && m_stateOfInteractable != null)
        {
            m_gameMode.GoToState(m_stateOfInteractable);
        }
    }
}
