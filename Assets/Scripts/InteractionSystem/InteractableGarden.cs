using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableGarden : MonoBehaviour
{
    [SerializeField] private PlantingState m_stateOfInteractable;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private WateringPotController m_wateringPotController;
    public bool active = false;
    private SoilHole m_soilHole;
    public SoilHole soilHole => m_soilHole;
    private Plant m_plant;
    public Plant plant => m_plant;

    public event Action onShow;
    public event Action onUnShow;

    private AudioManager m_audioManager;

    private void Start()
    {
        m_soilHole = gameObject.GetComponentInParent<SoilHole>();

        m_audioManager = GameManager.instance.audioManager;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        active = true;
        onShow?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
        onUnShow?.Invoke();
    }

    private void Update()
    {
        m_plant = gameObject.GetComponentInChildren<Plant>();
        if (active && Keyboard.current.eKey.wasPressedThisFrame && m_stateOfInteractable && m_gameMode)
        {
            if (!m_soilHole.isBusy)
            {
                m_gameMode.GoToPlanting();
                onUnShow?.Invoke();
            }
            else if (m_plant.isReadyToHarvest)
            {
                GameManager.instance.player.inventory.AddItem(m_plant.HarvestPlant());
                m_soilHole.GetBusy(false);

                m_audioManager.PlaySFX(m_audioManager.SFXPoppingElements);

                onUnShow?.Invoke();
            }
            else if (!m_plant.isWatered && GameManager.instance.player.wateringPot.currentValue > 0 && WateringState.isActive)
            {
                m_wateringPotController.WaterPlant();
                m_plant.WaterPlant();

                m_audioManager.PlaySFX(m_audioManager.SFXWateringPlants);

                onUnShow?.Invoke();
            }
        }
    }
}
