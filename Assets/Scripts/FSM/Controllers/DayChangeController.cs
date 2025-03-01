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
        yield return new WaitForSeconds(1f);

        m_gameManager.SaveData();
        m_questManager.SaveQuestInfo();

        //ДОБАВЬ СБРОС СВЕТА СЮДА!!
    }
}
