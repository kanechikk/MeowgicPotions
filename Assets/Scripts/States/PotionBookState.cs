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
        //получение списка всех существующих зелий
        m_potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");

        //динамическое создание кнопок, если они еще не были созданы
        GameObject curBtn;
        if (m_btnParent.transform.childCount == 0)
        {
            Debug.Log("Buttons created");
            foreach (var potion in m_potions)
            {
                curBtn = m_buttonsCreating.CreateObject(m_btnPrefab, m_btnParent.transform, potion.itemName);
                //добавление методов к кнопкам
                curBtn.GetComponent<Button>().onClick.AddListener(ShowPotionInfo);
                m_buttons.Add(curBtn);
            }
        }
        else
        {
            Debug.Log("Already have buttons");
        }
    }

    public void ShowPotionInfo()
    {
        //получение имени объекта, на который мы только то нажали
        //имена кнопок совпадают с соответствующими им зельями
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(clickedButtonName);

        //определяем, какое зелье мы выбрали
        foreach (var item in m_potions)
        {
            if (item.itemName == clickedButtonName)
            {
                m_chosenPotion = item;
                break;
            }
        }

        //выводим инвормацию о нем
        foreach (var element in m_potionInfo)
        {
            element.text = $"{element.name}: {m_chosenPotion.elements[element.name]}";
        }
    }

    //метод, который висит на кнопке "Выбрать"
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
        m_PotionBookUI.SetActive(false);
    }
}
