using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DayChangeController : MonoBehaviour
{
    [SerializeField] QuestManager m_questManager;
    [SerializeField] GameManager m_gameManager;
    [SerializeField] UIAnimation m_uiAnimation;
    public event Action onCoroutineStop;

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
