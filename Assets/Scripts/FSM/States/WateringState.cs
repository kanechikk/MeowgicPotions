using UnityEngine;

public class WateringState : GameStateBehaviour
{
    public static bool isActive = false;

    private void OnEnable()
    {
        isActive = true;

        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXPoppingElements);
    }

    private void OnDisable()
    {
        isActive = false;

        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXPoppingElements);
    }
}
