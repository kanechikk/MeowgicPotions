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

    private void Start()
    {
        m_soilHole = transform.GetComponentInParent<SoilHole>();
        m_plant = transform.GetComponentInChildren<Plant>();
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
        if (active && Keyboard.current.eKey.wasPressedThisFrame && m_stateOfInteractable && m_gameMode)
        {
            if (!m_soilHole.isBusy)
            {
                m_gameMode.GoToPlanting();
            }
            else if (m_plant.isReadyToHarvest)
            {
                GameManager.instance.player.inventory.AddItem(m_plant.HarvestPlant());
                m_soilHole.GetBusy(false);
            }
            else if (!m_plant.isWatered && GameManager.instance.player.wateringPot.currentValue > 0 && WateringState.isActive)
            {
                m_wateringPotController.WaterPlant();
                m_plant.WaterPlant();
            }
        }
    }
}
