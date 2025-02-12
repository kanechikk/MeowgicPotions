using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfo", menuName = "Scriptable Objects/QuestInfo")]
public class QuestInfo : ScriptableObject
{
	[SerializeField] private int m_id;
	[SerializeField] private int m_maxValue;
	[SerializeField] private string m_statusText;
	[SerializeField] private Item m_item;
	[SerializeField] private string m_questName;
	[SerializeField] private string m_questDescription;
	[SerializeField] private bool m_main;

	public int MaxValue => this.m_maxValue;
	public string StatusText => this.m_statusText;
	public int Id => this.m_id;
	public Item Item => this.m_item;
	public string QuestName => this.m_questName;
	public string QuestDecsription => this.m_questDescription;
	public bool Main => this.m_main;
}
