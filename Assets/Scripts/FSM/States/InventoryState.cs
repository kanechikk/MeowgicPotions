
public class InventoryState : GameStateBehaviour
{
    private void OnEnable()
    {
		GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBag);
	}

    private void OnDisable()
    {
		GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBag);
	}
}