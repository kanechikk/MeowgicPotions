using System;
public class ShoppingState : GameStateBehaviour
{
	public Action onActivated;

	private void OnEnable()
	{
		onActivated?.Invoke();
	}
}
