using UnityEngine;

public class BrewingState : MonoBehaviour
{
    private Item[] m_allIngredients;
    private Item[] m_allPotions;
    private Cauldron m_cauldron = new Cauldron();
    [SerializeField] private GameObject m_brewingUI;

    private void Start()
    {
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        m_allPotions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
    }

    //очищение котла, обнуление значений
    public void ClearCauldron()
    {
        m_cauldron.ClearAll();
    }
}
