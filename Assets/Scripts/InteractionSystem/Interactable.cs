using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameStateBehaviour m_stateOfInteractable;
    public GameStateBehaviour stateOfInteractable => m_stateOfInteractable;
    [SerializeField] private WateringPotController m_wateringPotController;
    public WateringPotController wateringPotController => m_wateringPotController;
    [SerializeField] private GameMode m_gameMode;
    private bool m_active = false;

    public Action onActive;
    public Action onDeactive;

    private AudioManager m_audioManager;

    private void Start()
    {
        m_audioManager = GameManager.instance.audioManager;
    }

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
            else if (m_wateringPotController != null && m_wateringPotController.gameObject.activeSelf)
            {
                m_wateringPotController.FillPot();

                m_audioManager.PlaySFX(m_audioManager.SFXGettingWater);
            }
            m_active = false;
            onDeactive?.Invoke();
        }
    }
}
