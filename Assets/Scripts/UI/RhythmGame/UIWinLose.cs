using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWinLose : MonoBehaviour
{
    [SerializeField] private GameObject m_reward;
    [SerializeField] private GameObject[] m_loss;
    private List<UIInventoryItem> m_lossItems;
    private UIInventoryItem m_rewardPotion;
    public Potion potion;
    public Ingredient[] ingredients;

    private void Start()
    {
        // foreach (GameObject item in m_loss)
        // {
        //     m_lossItems.Add(item.GetComponent<UIInventoryItem>());
        // }
        // m_rewardPotion = m_reward.GetComponent<UIInventoryItem>();
    }

    public void ChangePotion()
    {
        //m_rewardPotion.InitialiseItem(potion, 1);
        m_rewardPotion.GetComponent<Image>().sprite = potion.icon;
        m_rewardPotion.GetComponentInChildren<TextMeshProUGUI>().text = "1";
    }

    public void ChangeIngredients()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            m_loss[i].GetComponent<Image>().sprite = ingredients[i].icon;
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
