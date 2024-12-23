using System;
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
    [SerializeField] private GameObject m_PotionBookUI;
    private Potion[] m_potions;
    private List<GameObject> m_buttons = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI[] m_potionInfo;
    public event Action<Potion> onChoosePotion;
    private Potion m_chosenPotion;

    private void OnEnable()
    {
        m_PotionBookUI.SetActive(true);
        m_potions = m_brewingState.allPotions;
        GameObject curBtn;
        foreach (var potion in m_potions)
        {
            curBtn = m_buttonsCreating.CreateObject(m_btnPrefab, m_btnParent, potion.itemName);
            curBtn.GetComponent<Button>().onClick.AddListener(ShowPotionInfo);
            m_buttons.Add(curBtn);
        }
    }

    public void ShowPotionInfo()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(clickedButtonName);
        foreach (var item in m_potions)
        {
            if (item.itemName == clickedButtonName)
            {
                m_chosenPotion = item;
                break;
            }
        }

        foreach (var element in m_potionInfo)
        {
            switch (element.name)
            {
                case "Aqua":
                    element.text = $"Aqua: {m_chosenPotion.elements["aqua"]}";
                break;
                case "Terra":
                    element.text = $"Terra: {m_chosenPotion.elements["terra"]}";
                break;
                case "Solar":
                    element.text = $"Solar: {m_chosenPotion.elements["solar"]}";
                break;
                case "Ignis":
                    element.text = $"Ignis: {m_chosenPotion.elements["ignis"]}";
                break;
                case "Aer":
                    element.text = $"Aer: {m_chosenPotion.elements["aer"]}";
                break;
            }
        }
    }

    public void ChoosePotion()
    {
        onChoosePotion?.Invoke(m_chosenPotion);
        CloseBook();
    }

    public void CloseBook()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        foreach (var btn in m_buttons)
        {
            Destroy(btn);
        }
        m_PotionBookUI.SetActive(false);
    }
}
