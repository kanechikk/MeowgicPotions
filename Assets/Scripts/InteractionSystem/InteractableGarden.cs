using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableGarden : MonoBehaviour
{
    [SerializeField] private PlantingState m_stateOfInteractable;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private WateringPotController m_wateringPotController;
    public bool active = false;
    private SoilHole m_soilHole;
    private Plant plant;

    private void Start()
    {
        m_soilHole = transform.GetComponentInParent<SoilHole>();
        plant = transform.GetComponentInChildren<Plant>();
    }
    
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
        if (active && Keyboard.current.eKey.wasPressedThisFrame && m_stateOfInteractable && m_gameMode)
        {
            if (!m_soilHole.isBusy)
            {
                m_gameMode.GoToPlanting();
            }
            else if (plant.isReadyToHarvest)
            {
                GameManager.instance.player.inventory.AddItem(plant.HarvestPlant());
                m_soilHole.GetBusy(false);
            }
            else if (!plant.isWatered && GameManager.instance.player.wateringPot.currentValue > 0 && WateringState.isActive)
            {
                m_wateringPotController.WaterPlant();
                plant.WaterPlant();
            }
        }
    }
}
