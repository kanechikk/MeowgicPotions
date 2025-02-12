using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameStateBehaviour stateOfInteractable;
    [SerializeField] private WateringPotController m_wateringPotController;
    [SerializeField] private GameMode m_gameMode;
    private bool m_active = false;

    public Action onActive;
    public Action onDeactive;
    
    private void OnTriggerEnter(Collider other)
    {
        m_active = true;
        onActive?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        m_active = false;
        onDeactive?.Invoke();
    }

    private void OnDisable()
    {
        m_active = false;
        onDeactive?.Invoke();
    }

    private void Update()
    {
        if (m_active && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (stateOfInteractable != null)
            {
                m_gameMode.GoToState(stateOfInteractable);
            }
            else if (m_wateringPotController != null)
            {
                m_wateringPotController.FillPot();
            }
            m_active = false;
            onDeactive?.Invoke();
        }
    }
}
