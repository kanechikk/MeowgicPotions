using UnityEngine;

public class GameInstance : MonoBehaviour
{
    [SerializeField] private Transform m_states;
    private void Start()
    {
        foreach (Transform child in m_states)
        {
            child.gameObject.SetActive(false);
        }

        m_states.GetChild(0).gameObject.SetActive(true);
    }
}
