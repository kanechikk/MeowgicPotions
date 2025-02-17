using UnityEngine;

public class WateringPotController : MonoBehaviour
{
    [SerializeField] private GameManager m_gameManager;
    [SerializeField] private WaterBarUI m_waterBarUI;

    public void WaterPlant()
    {
        m_gameManager.wateringPot.UsePot();
        
        m_waterBarUI.SetWater(CountPercent(m_gameManager.wateringPot.currentValue, m_gameManager.wateringPot.maxValue));
    }

    public void FillPot()
    {
        m_gameManager.wateringPot.FillPot();
        m_waterBarUI.SetWater(100);
    }

    // public void ExtendPot(int newMaxValue)
    // {
    //     m_gameManager.wateringPot = new WateringPot(newMaxValue);
    // }

    private float CountPercent(float value, float maxValue)
    {
        return (value / maxValue) * 100;
    }
}
