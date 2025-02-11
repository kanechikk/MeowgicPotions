using UnityEngine;

public class WalkingState : GameStateBehaviour
{
	private void OnEnable()
	{
		Time.timeScale = 1;
	}
	private void OnDisable()
	{
		Time.timeScale = 0;
	}
}
