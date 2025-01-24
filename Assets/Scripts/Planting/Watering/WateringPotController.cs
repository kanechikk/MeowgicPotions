using UnityEngine;

public class WateringPotController : MonoBehaviour
{
    [SerializeField] private GameManager m_gameManager;

    public void WaterPlant()
    {
        m_gameManager.wateringPot.UsePot();
    }

    public void FillPot()
    {
        m_gameManager.wateringPot.FillPot();
        Debug.Log(m_gameManager.wateringPot.currentValue);
    }

    public void ExtendPot(int newMaxValue)
    {
        m_gameManager.wateringPot = new WateringPot(newMaxValue);
    }
}
