using UnityEngine;

public class PlantsManager : MonoBehaviour
{
    [SerializeField] private DayTimeManager m_dayTimeManager;
    [SerializeField] private Plant[] m_plants;
    public Plant[] plants => m_plants;

    private void Start()
    {
        foreach (Plant plant in m_plants)
        {
            plant.SubscribeOnDayTimeManager(m_dayTimeManager);
        }
    }
}
