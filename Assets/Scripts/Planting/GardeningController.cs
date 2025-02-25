using UnityEngine;

public class GardeningController : MonoBehaviour
{
    [SerializeField] private PlantsManager m_plantsManager;
    
    private Plant m_plant;

    private void Awake()
    {
        m_plant = GetComponentInChildren<Plant>();
        m_plantsManager.onPlantSeed += OnPlantSeed;
        m_plant.gameObject.SetActive(false);
    }

    private void OnPlantSeed(Seed seed)
    {
        Debug.Log("OnPlanting");
        if (GetComponentInChildren<InteractableGarden>().active)
        {
            m_plant.gameObject.SetActive(true);
            m_plant.PlantSeed(seed);
        }
    }
}
