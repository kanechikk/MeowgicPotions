using UnityEngine;

public class RhythmGameState : GameStateBehaviour
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
