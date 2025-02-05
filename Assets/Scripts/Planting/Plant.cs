using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private Ingredient m_plant;
    private int m_daysAfterPlanting = 0;
    private Seed m_seed;
    private bool m_isWatered = false;
    public bool isWatered => m_isWatered;
    private bool m_isReadyToHarvest;
    public bool isReadyToHarvest => m_isReadyToHarvest;

    //подписываемся на событие смены дня
    public void SubscribeOnDayTimeManager(DayTimeManager dayTimeManager)
    {
        dayTimeManager.onDayChange += OnDayChange;
    }

    public void PlantSeed(Seed seed)
    {
        Debug.Log($"{seed.itemName} is planted");
        m_seed = seed;
        //по имени ищем ингредиент, семечко которого посадили
        //позже строчку нужно будет поменять
        m_plant = Array.Find(GameManager.itemsDB.ingredients, x => x.Id == seed.Id);
        //показываем росток
        ShowPlant(transform.GetChild(0).gameObject);
        //получаем картинку посаженного растения
        
        Renderer ren = transform.GetChild(1).GetComponent<Renderer>();
        Material[] mat = ren.materials;
        mat[0] = m_plant.material;
        ren.materials = mat;

        transform.GetComponentInParent<SoilHole>().GetBusy(true);
    }

    private void ShowPlant(GameObject plant)
    {
        plant.SetActive(true);
    }

    private void UnshowPlant(GameObject plant)
    {
        plant.SetActive(false);
    }

    //помечаем, полито ли сегодня растение
    public void WaterPlant()
    {
        m_isWatered = true;
        Debug.Log($"{m_seed} is watered");
    }

    private void OnDayChange()
    {
        if (m_seed != null)
        {
            //при смене дня, если растение было полито, оно продолжает расти, если нет, то нет
            if (m_isWatered)
            {
                m_daysAfterPlanting += 1;
                m_isWatered = false;
            }
            //если растение выросло, мы показываем спрайт вырасшего растения, скрываем росток
            //помечаем, что растение готово для сбора
            if (m_daysAfterPlanting == m_seed.daysToGrow)
            {
                UnshowPlant(transform.GetChild(0).gameObject);
                ShowPlant(transform.GetChild(1).gameObject);
                m_isReadyToHarvest = true;
            }
        }

    }

    public Ingredient HarvestPlant()
    {
        //если растение готово для сбора, то мы обнуляем значения и возвращаем объект ингредиента, который вырос
        if (m_isReadyToHarvest)
        {
            m_daysAfterPlanting = 0;
            m_isReadyToHarvest = false;
            UnshowPlant(transform.GetChild(1).gameObject);
            Debug.Log($"{m_seed} is harvested");
            return m_plant;
        }
        else
        {
            return null;
        }
    }
}
