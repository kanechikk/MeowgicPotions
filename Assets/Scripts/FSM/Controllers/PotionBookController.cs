using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionBookController : MonoBehaviour
{
    private Potion[] m_potions;
    private List<GameObject> m_buttons;
    public event Action<Potion> onChoosePotion;
    private Potion m_chosenPotion;
    //UI элементы
    [SerializeField] private TextMeshProUGUI m_potionInfo;
    [SerializeField] private GameObject m_btnPrefab;
    [SerializeField] private GameObject m_btnParent;
    [SerializeField] private ButtonsCreating m_buttonsCreating;
    [SerializeField] private Image m_sprite;
    [SerializeField] private TextMeshProUGUI m_description;

    private void Awake()
    {
        m_buttons = new List<GameObject>();
    }
    private void OnEnable()
    {
        //динамическое создание кнопок, если они еще не были созданы
        GameObject curBtn;
        if (m_btnParent.transform.childCount == 0)
        {
            foreach (var potion in GameManager.itemsDB.potions)
            {
                curBtn = m_buttonsCreating.CreateObject(m_btnPrefab, m_btnParent.transform, potion.icon, potion.itemName);
                //добавление методов к кнопкам
                curBtn.GetComponent<Button>().onClick.AddListener(ShowPotionInfo);
                m_buttons.Add(curBtn);
            }
        }
    }

    public void ShowPotionInfo()
    {
        //получение имени объекта, на который мы только то нажали
        //имена кнопок совпадают с соответствующими им зельями
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        //определяем, какое зелье мы выбрали
        foreach (var potion in GameManager.itemsDB.potions)
        {
            if (potion.itemName == clickedButtonName)
            {
                m_chosenPotion = potion;
                break;
            }
        }

        m_sprite.sprite = m_chosenPotion.icon;
        m_description.text = m_chosenPotion.description;
        m_potionInfo.text = m_chosenPotion.ElementsToString();
    }

    //метод, который висит на кнопке "Выбрать"
    public void ChoosePotion()
    {
        onChoosePotion?.Invoke(m_chosenPotion);
    }
}
