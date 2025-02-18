using UnityEngine;

public class WateringPotController : MonoBehaviour
{
    [SerializeField] private WaterBarUI m_waterBarUI;

    public void WaterPlant()
    {
        GameManager.instance.player.wateringPot.UsePot();
        
        m_waterBarUI.SetWater(CountPercent(GameManager.instance.player.wateringPot.currentValue, GameManager.instance.player.wateringPot.maxValue));
    }

    public void FillPot()
    {
        GameManager.instance.player.wateringPot.FillPot();
        m_waterBarUI.SetWater(100);
    }

    private float CountPercent(float value, float maxValue)
    {
        return (value / maxValue) * 100;
    }
}
