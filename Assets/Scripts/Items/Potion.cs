using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : Item
{
    [SerializeField] private int m_aqua;
    [SerializeField] private int m_terra;
    [SerializeField] private int m_solar;
    [SerializeField] private int m_ignis;
    [SerializeField] private int m_aer;
    private Dictionary<string, int> m_elements;

    public Dictionary<string, int> elements => this.m_elements;

    private void OnEnable()
    {
        m_elements = new Dictionary<string, int>()
        {
            {"Aqua", m_aqua},
            {"Terra", m_terra},
            {"Solar", m_solar},
            {"Ignis", m_ignis},
            {"Aer", m_aer}
        };
    }
    public string ElementsToString()
    {
        return $"Aqua: {m_aqua}\nTerra: {m_terra}\nSolar: {m_solar}\nIgnis: {m_ignis}\nAer: {m_aer}";
    }
}