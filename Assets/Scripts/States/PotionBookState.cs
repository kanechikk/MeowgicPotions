using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionBookState : MonoBehaviour
{
    [SerializeField] private GameObject m_btnPrefab;
    [SerializeField] private GameObject m_btnParent;
    [SerializeField] private ButtonsCreating m_buttonsCreating;
    [SerializeField] private BrewingState m_brewingState;
    private Potion[] m_potions;
    private List<GameObject> m_potionButtons;
    [SerializeField] private TextMeshProUGUI[] m_potionInfo;

    private void OnEnable()
    {
        m_potions = m_brewingState.allPotions;
        GameObject curBtn;
        foreach (var potion in m_potions)
        {
            curBtn = m_buttonsCreating.CreateObject(m_btnPrefab, m_btnParent, potion.itemName);
            curBtn.GetComponent<Button>().onClick.AddListener(ChoosePotion);
        }
    }

    private void Update()
    {

    }

    public void ChoosePotion()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(clickedButtonName);
        Potion currentPotion = new();
        foreach (var item in m_potions)
        {
            if (item.itemName == clickedButtonName)
            {
                currentPotion = item;
                break;
            }
        }

        foreach (var element in m_potionInfo)
        {
            switch (element.name)
            {
                case "Aqua":
                    element.text = $"Aqua: {currentPotion.elements["aqua"]}";
                break;
                case "Terra":
                    element.text = $"Terra: {currentPotion.elements["terra"]}";
                break;
                case "Solar":
                    element.text = $"Solar: {currentPotion.elements["solar"]}";
                break;
                case "Ignis":
                    element.text = $"Ignis: {currentPotion.elements["ignis"]}";
                break;
                case "Aer":
                    element.text = $"Aer: {currentPotion.elements["aer"]}";
                break;
            }
        }
    }
}
