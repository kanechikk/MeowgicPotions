using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfo", menuName = "Scriptable Objects/QuestInfo")]
public class QuestInfo : ScriptableObject
{
	[SerializeField] private string m_eventTrigger;
	[SerializeField] private int m_maxValue;
	[SerializeField] private string m_statusText;

	public string EventTrigger => this.m_eventTrigger;
	public int MaxValue => this.m_maxValue;
	public string StatusText => this.m_statusText;
}
