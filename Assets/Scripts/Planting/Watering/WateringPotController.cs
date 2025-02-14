using UnityEngine;

public class WateringPotController : MonoBehaviour
{
    public void WaterPlant()
    {
        GameManager.instance.player.wateringPot.UsePot();
        Debug.Log($"Watering Pot: {GameManager.instance.player.wateringPot.currentValue}");
    }

    public void FillPot()
    {
        GameManager.instance.player.wateringPot.FillPot();
        Debug.Log($"Watering Pot: {GameManager.instance.player.wateringPot.currentValue}");
    }

    public void ExtendPot(int newMaxValue)
    {
        GameManager.instance.player.wateringPot = new WateringPot(newMaxValue);
    }
}
