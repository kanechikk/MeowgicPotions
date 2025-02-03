using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    private TMPro.TextMeshProUGUI m_text;
    private Color m_color;
    void OnEnable()
    {
        Destroy(gameObject, 3f);
        m_text = GetComponent<TMPro.TextMeshProUGUI>();
        m_color = m_text.color;
        m_color.a = 0;
    }
    void Update()
    {
        m_text.color = Color.Lerp(m_text.color, m_color, 1.5f * Time.deltaTime);
        transform.position += new Vector3(0, 70f * Time.deltaTime, 0);
    }

}