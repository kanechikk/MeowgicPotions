using UnityEngine;

public class GardeningController : MonoBehaviour
{
    [SerializeField] private PlantingState m_plantingState;
    private Plant m_plant;

    private void Start()
    {
        m_plant = GetComponentInChildren<Plant>();
        m_plantingState.onPlantSeed += OnPlantSeed;
    }

    private void OnPlantSeed(Seed seed)
    {
        m_plant.PlantSeed(seed);
    }
}
