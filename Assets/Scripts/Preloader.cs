using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Preloader : MonoBehaviour
{
    [SerializeField] private Image m_progressBar;

    private IEnumerator Start()
    {
        m_progressBar.fillAmount = 0;

        while (GameManager.instance == null)
        {
            yield return 0;
        }

        m_progressBar.fillAmount = 0.5f;

        GameManager.instance.LoadPlayerData();
        GameManager.instance.LoadShop();

        yield return 0;

        m_progressBar.fillAmount = 1f;

        yield return 0;

        SceneManager.LoadScene("MainScene");

        yield break;
    }
}
