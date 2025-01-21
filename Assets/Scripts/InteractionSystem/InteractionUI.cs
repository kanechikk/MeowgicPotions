using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    private Camera m_mainCamera;

    private void Awake()
    {
        m_mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        var rotation = m_mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
