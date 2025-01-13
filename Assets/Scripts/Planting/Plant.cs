using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Sprite m_sprite;
    private Ingredient m_plant;
    private int m_daysAfterPlanting = 0;
    private bool m_isWatered;

    public Plant(Seed seed)
    {
        m_plant = Array.Find(GamePlayState.ingredients, x => x.itemName == seed.itemName);
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        if (m_plant != null)
        {
            
        }
    }
}
