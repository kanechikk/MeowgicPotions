using System;
using UnityEngine;

public class CheckingQuestsState : GameStateBehaviour
{
    public Action onActivated;

	private void OnEnable()
	{
		onActivated?.Invoke();
	}
}
