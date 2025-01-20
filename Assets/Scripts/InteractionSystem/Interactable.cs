using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject stateOfInteractable;
    [SerializeField] private GameObject uiSign;
    private bool active = false;
    
    private void OnTriggerEnter(Collider other)
    {
        active = true;
        uiSign.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
        uiSign.SetActive(false);
    }

    private void Update()
    {
        if (active && Keyboard.current.eKey.wasPressedThisFrame && stateOfInteractable != null)
        {
            stateOfInteractable.SetActive(true);
        }
    }
}
