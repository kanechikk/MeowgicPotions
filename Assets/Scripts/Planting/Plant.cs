using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private Ingredient m_plant;
    private int m_daysAfterPlanting = 0;
    private Seed m_seed;
    private bool m_isWatered = false;
    private bool m_isReadyToHarvest;
    [SerializeField] private DayTimeManager m_dayTimeManager;

    private void Start()
    {
        m_dayTimeManager.onDateTimeChange += OnDateTimeChange;
    }

    public void PlantSeed(Seed seed)
    {
        m_seed = seed;
        Debug.Log(seed);
        Debug.Log(seed.itemName);
        m_plant = Array.Find(LevelController.ingredients, x => $"{x.itemName} Seed" == seed.itemName);
        Debug.Log(m_plant);
        ShowPlant(transform.GetChild(0).gameObject);
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = m_plant.icon;
    }

    private void ShowPlant(GameObject plant)
    {
        plant.SetActive(true);
    }

    private void UnshowPlant(GameObject plant)
    {
        plant.SetActive(false);
    }

    public void WaterPlant()
    {
        m_isWatered = true;
    }

    private void OnDateTimeChange()
    {
        if (m_isWatered)
        {
            m_daysAfterPlanting += 1;
            m_isWatered = false;
        }

        if (m_daysAfterPlanting == m_seed.daysToGrow)
        {
            UnshowPlant(transform.GetChild(0).gameObject);
            ShowPlant(transform.GetChild(1).gameObject);
            m_isReadyToHarvest = true;
        }
    }

    public Ingredient HarvestPlant()
    {
        if (m_isReadyToHarvest)
        {
            m_daysAfterPlanting = 0;
            m_isReadyToHarvest = false;
            UnshowPlant(transform.GetChild(1).gameObject);
            return m_plant;
        }
        else
        {
            return null;
        }
    }
}
