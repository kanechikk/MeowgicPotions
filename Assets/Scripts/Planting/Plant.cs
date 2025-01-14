using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private Ingredient m_plant;
    private int m_daysAfterPlanting = 0;
    private Seed m_seed;
    private bool m_isWatered = false;
    private bool m_isReadyToHarvest;

    //подписываемся на событие смены дня
    public void SubscribeOnDayTimeManager(DayTimeManager dayTimeManager)
    {
        dayTimeManager.onDateTimeChange += OnDateTimeChange;
    }

    public void PlantSeed(Seed seed)
    {
        m_seed = seed;
        //по имени ищем ингредиент, семечко которого посадили
        //позже строчку нужно будет поменять
        m_plant = Array.Find(GardenLevelController.ingredients, x => $"{x.itemName} Seed" == seed.itemName);
        //показываем росток
        ShowPlant(transform.GetChild(0).gameObject);
        //получаем картинку посаженного растения
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

    //помечаем, полито ли сегодня растение
    public void WaterPlant()
    {
        m_isWatered = true;
    }

    private void OnDateTimeChange()
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

    public Ingredient HarvestPlant()
    {
        //если растение готово для сбора, то мы обнуляем значения и возвращаем объект ингредиента, который вырос
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
