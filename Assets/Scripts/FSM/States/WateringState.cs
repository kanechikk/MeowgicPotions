using UnityEngine;

public class WateringState : GameStateBehaviour
{
    public static bool isActive = false;

    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }
}
