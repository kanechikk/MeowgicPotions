using UnityEngine;

public class PotionManager : MonoBehaviour
{
    private Item[] m_allIngredients;
    private Item[] m_allPotions;

    private void Start()
    {
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        m_allPotions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
    }
}