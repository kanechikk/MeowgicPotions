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
            {"aqua", m_aqua},
            {"terra", m_terra},
            {"solar", m_solar},
            {"ignis", m_ignis},
            {"aer", m_aer}
        };
    }
}
