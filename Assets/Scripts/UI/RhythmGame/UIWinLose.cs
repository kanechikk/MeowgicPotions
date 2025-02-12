using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWinLose : MonoBehaviour
{
    [SerializeField] private GameObject m_reward;
    [SerializeField] private GameObject m_loss;
    private UIInventoryItem[] m_uiInventoryItem;

    public Potion potion;
    public Ingredient[] ingredients;

    private void Start()
    {
        m_uiInventoryItem = m_loss.GetComponentsInChildren<UIInventoryItem>();
    }

    public void ChangePotion()
    {
        m_reward.GetComponentInChildren<UIInventoryItem>().InitialiseItem(potion, 1);
    }

    public void ChangeIngredients()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            m_uiInventoryItem[i].gameObject.SetActive(true);
            foreach (UIInventoryItem item in m_uiInventoryItem)
            {
                if (item.item == ingredients[i])
                {
                    item.InitialiseItem(ingredients[i], int.Parse(item.gameObject.GetComponent<TextMeshProUGUI>().text));
                }

                item.InitialiseItem(ingredients[i], 1);
            }
        }
    }

    private void OnDisable()
    {
        foreach (Transform child in m_loss.transform) 
        {
            child.gameObject.SetActive(false);
        }
    }
}
