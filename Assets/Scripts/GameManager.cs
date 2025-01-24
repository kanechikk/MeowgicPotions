using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WateringPot m_wateringPot;
    public WateringPot wateringPot => m_wateringPot;
    [SerializeField] private int m_wateringPotMaxValue;
    private void OnEnable()
    {
        CreateWateringPot(m_wateringPotMaxValue);
    }

    private void CreateWateringPot(int maxValue)
    {
        m_wateringPot = new WateringPot(maxValue);
    }
}
