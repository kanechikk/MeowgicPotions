using JetBrains.Annotations;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    private Item[] m_allIngredients;
    private Item[] m_allPotions;
    private Cauldron m_cauldron;

    private void Start()
    {
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        m_allPotions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");

        m_cauldron = new Cauldron();
    }
}
