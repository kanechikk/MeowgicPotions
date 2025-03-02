using UnityEngine;

public class MarkUI : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    private void Update()
    {
        transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward, m_camera.transform.rotation * Vector3.up);
    }
}
