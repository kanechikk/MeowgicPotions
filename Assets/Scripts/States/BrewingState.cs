using TMPro;
using UnityEngine;

public class BrewingState : MonoBehaviour
{
    private Ingredient[] m_allIngredients;
    private Potion[] m_allPotions;
    [SerializeField] private Cauldron m_cauldron;
    [SerializeField] private GameObject m_brewingUI;
    [SerializeField] private TextMeshProUGUI[] m_cauldronInfo;

    //свойства, доступные только для чтения
    public Potion[] allPotions => this.m_allPotions;

    private void OnEnable()
    {
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        m_allPotions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
    }

    //обновление значений элементов в котле в UI
    //вызывается при каждом добавлении/удалении ингредиента
    public void CauldronInfoChange()
    {
        foreach (var element in m_cauldronInfo)
        {
            switch (element.name)
            {
                case "Aqua":
                    element.text = $"Aqua: {m_cauldron.aquaCount}";
                break;
                case "Terra":
                    element.text = $"Terra: {m_cauldron.terraCount}";
                break;
                case "Solar":
                    element.text = $"Solar: {m_cauldron.solarCount}";
                break;
                case "Ignis":
                    element.text = $"Ignis: {m_cauldron.ignisCount}";
                break;
                case "Aer":
                    element.text = $"Aer: {m_cauldron.aerCount}";
                break;
            }
        }
    }

    //очищение котла, обнуление значений
    public void ClearCauldron()
    {
        m_cauldron.ClearAll();
        CauldronInfoChange();
    }
}
