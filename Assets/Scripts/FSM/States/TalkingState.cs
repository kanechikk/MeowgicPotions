using UnityEngine;
using Unity.Cinemachine;

public class TalkingState : GameStateBehaviour
{
	[SerializeField] private CinemachineCamera m_counterCamera;

	private void OnEnable()
	{
		m_counterCamera.Priority = 100;
	}

	private void OnDisable()
	{
		m_counterCamera.Priority = 0;
	}
}
