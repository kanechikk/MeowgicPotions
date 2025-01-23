using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameStateBehaviour stateOfInteractable;
    [SerializeField] private GameMode m_gameMode;
    private bool active = false;
    
    private void OnTriggerEnter(Collider other)
    {
        active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
    }

    private void Update()
    {
        if (active && Keyboard.current.eKey.wasPressedThisFrame && stateOfInteractable != null)
        {
            m_gameMode.GoToState(stateOfInteractable);
        }
    }
}
