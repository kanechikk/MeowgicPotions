using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfo", menuName = "Scriptable Objects/QuestInfo")]
public class QuestInfo : ScriptableObject
{
	[SerializeField] private int m_id;
	[SerializeField] private string m_eventTrigger;
	[SerializeField] private int m_maxValue;
	[SerializeField] private string m_statusText;
	[SerializeField] private int m_day;

	public string EventTrigger => this.m_eventTrigger;
	public int MaxValue => this.m_maxValue;
	public string StatusText => this.m_statusText;
	public int Id => this.m_id;
	public int Day => this.m_day;
}
