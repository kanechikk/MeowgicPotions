using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionBookState : MonoBehaviour
{
    private Potion[] m_potions;
    private List<GameObject> m_buttons;
    public event Action<Potion> onChoosePotion;
    private Potion m_chosenPotion;
    //UI элементы
    [SerializeField] private TextMeshProUGUI[] m_potionInfo;
    [SerializeField] private GameObject m_btnPrefab;
    [SerializeField] private GameObject m_btnParent;
    [SerializeField] private ButtonsCreating m_buttonsCreating;
    [SerializeField] private GameObject m_PotionBookUI;
    
    private void Awake()
    {
        m_buttons = new List<GameObject>();
    }
    private void OnEnable()
    {
        m_PotionBookUI.SetActive(true);
        m_potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");

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
            element.text = $"{element.name}: {m_chosenPotion.elements[element.name]}";
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
