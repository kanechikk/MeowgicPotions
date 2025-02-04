using UnityEngine;

public class DeleteChildren : MonoBehaviour
{
    [SerializeField] private GameObject m_object;
    private void OnDisable()
    {
        while (m_object.transform.childCount > 0)
        {
            DestroyImmediate(m_object.transform.GetChild(0).gameObject);
        }
    }
}
