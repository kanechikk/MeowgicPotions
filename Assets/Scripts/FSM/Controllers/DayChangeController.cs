using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DayChangeController : MonoBehaviour
{
    [SerializeField] QuestManager m_questManager;
    GameManager m_gameManager;
    public event Action onCoroutineStop;

    private void Start()
    {
        m_gameManager = FindAnyObjectByType<GameManager>();
    }

    public IEnumerator SavingInfo()
    {
        Debug.Log("saving");
        yield return new WaitForSecondsRealtime(3.0f);

        Debug.Log("after 3 seconds");

        m_gameManager.SaveData();
        m_questManager.SaveQuestInfo();

        onCoroutineStop?.Invoke();
    }
}
