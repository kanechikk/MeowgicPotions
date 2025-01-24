using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WateringPot wateringPot;
    [SerializeField] private int m_wateringPotMaxValue;
    private void OnEnable()
    {
        CreateWateringPot(m_wateringPotMaxValue);
        Debug.Log($"Watering Pot: {wateringPot.currentValue}");
    }

    private void CreateWateringPot(int maxValue)
    {
        wateringPot = new WateringPot(maxValue);
    }
}
