using UnityEngine;

public class GardeningController : MonoBehaviour
{
    [SerializeField] private PlantingState m_plantingState;
    
    private Plant m_plant;

    private void Start()
    {
        m_plant = GetComponentInChildren<Plant>();
        m_plantingState.onPlantSeed += OnPlantSeed;
        m_plant.gameObject.SetActive(false);
    }

    private void OnPlantSeed(Seed seed)
    {
        if (GetComponentInChildren<InteractableGarden>().active)
        {
            m_plant.gameObject.SetActive(true);
            m_plant.PlantSeed(seed);
        }
    }
}
