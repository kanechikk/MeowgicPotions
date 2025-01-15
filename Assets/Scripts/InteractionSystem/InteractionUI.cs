using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    private Camera m_mainCamera;
    public GameObject pressIcon;

    private void Awake()
    {
        m_mainCamera = Camera.main;
    }

    private void Start()
    {
        pressIcon.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = m_mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
