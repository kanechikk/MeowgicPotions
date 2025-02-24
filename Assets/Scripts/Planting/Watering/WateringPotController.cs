using UnityEngine;

public class WateringPotController : MonoBehaviour
{
    [SerializeField] private WaterBarUI m_waterBarUI;
    private WateringPot m_wateringPot;

    private void Awake()
    {
        m_wateringPot = GameManager.instance.player.wateringPot;
        m_wateringPot.onValueChange += OnValueChange;  
        OnValueChange();
    }
    public void WaterPlant()
    {
        m_wateringPot.UsePot();
    }

    public void FillPot()
    {
        m_wateringPot.FillPot();
    }

    private void OnValueChange()
    {
        m_waterBarUI.SetWater(m_wateringPot.currentValue);
    }
}
