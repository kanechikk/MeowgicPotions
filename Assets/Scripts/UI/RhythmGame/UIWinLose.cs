using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWinLose : MonoBehaviour
{
    [SerializeField] private GameObject m_reward;
    public GameObject reward => m_reward;
    [SerializeField] private GameObject[] m_loss;
    public GameObject[] loss => m_loss;
    public List<RectTransform> lossItems;
    public RectTransform rewardPotion;
    public Potion potion;
    public Ingredient[] ingredients;


    public void ChangePotion()
    {
        //m_rewardPotion.InitialiseItem(potion, 1);
        m_reward.GetComponent<Image>().sprite = potion.icon;
        rewardPotion = m_reward.GetComponent<RectTransform>();
    }

    public void ChangeIngredients()
    {
        lossItems.Clear();
        for (int i = 0; i < ingredients.Length; i++)
        {
            m_loss[i].GetComponent<Image>().sprite = ingredients[i].icon;
            lossItems.Add(m_loss[i].GetComponent<RectTransform>());
        }

        if (ingredients.Length < m_loss.Length)
        {
            for (int i = ingredients.Length; i < m_loss.Length; i++)
            {
                m_loss[i].SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject item in m_loss) 
        {
            item.SetActive(true);
        }
    }
}
