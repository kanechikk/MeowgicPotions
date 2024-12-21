using UnityEngine;

public class PotionBookState : MonoBehaviour
{
    [SerializeField] private GameObject m_btnPrefab;
    [SerializeField] private GameObject m_btnParent;
    private ButtonsCreating m_buttonsCreating;
    [SerializeField] private BrewingState m_brewingState;
    private void Start()
    {
        Potion[] potions = m_brewingState.allPotions;
        m_buttonsCreating = new ButtonsCreating();
        foreach (var potion in potions)
        {
            m_buttonsCreating.CreateObject(m_btnPrefab, m_btnParent, potion.itemName);
        }
    }
}
