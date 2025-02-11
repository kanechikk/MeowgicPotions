using UnityEngine;
using Unity.Cinemachine;
using System;

public class TalkingState : GameStateBehaviour
{
	[SerializeField] private CinemachineCamera m_counterCamera;
	public Action onActivated;

	private void OnEnable()
	{
		m_counterCamera.Priority = 100;
		onActivated?.Invoke();
	}

	private void OnDisable()
	{
		m_counterCamera.Priority = 0;
	}
}
