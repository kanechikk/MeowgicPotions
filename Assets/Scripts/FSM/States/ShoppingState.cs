using System;
public class ShoppingState : GameStateBehaviour
{
	public Action onActivated;

	private void OnEnable()
	{
		onActivated?.Invoke();

		GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBook);
	}

	private void OnDisable()
	{
		GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBook);
	}
}
