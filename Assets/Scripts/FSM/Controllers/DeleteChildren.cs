using System.Collections.Generic;
using UnityEngine;

public class DeleteChildren : MonoBehaviour
{
    [SerializeField] private GameObject m_object;
    private void OnDisable()
    {
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < m_object.transform.childCount; i ++)
        {
            children.Add(m_object.transform.GetChild(i).gameObject);
        }
        foreach (GameObject child in children)
        {
            Destroy(child);
        }
        Debug.Log("workedRithmUI");
    }
}
