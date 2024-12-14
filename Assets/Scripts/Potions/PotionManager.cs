using UnityEngine;

public class PotionManager : MonoBehaviour
{
    private void Start()
    {
        var allIngredientsInfo = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        foreach (var item in allIngredientsInfo)
        {
            Debug.Log(item.itemName);
        }
    }
}
