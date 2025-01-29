using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private string m_triggerTag;
    [SerializeField] private CinemachineCamera m_workShopCamera;
    [SerializeField] private CinemachineCamera[] m_cinemachineCameras;

    private void Start()
    {
        SwitchToCamera(m_workShopCamera);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_triggerTag))
        {
            SwitchToCamera(other.GetComponentInChildren<CinemachineCamera>());
        }
    }

    private void SwitchToCamera(CinemachineCamera targetCamera)
    {
        foreach (CinemachineCamera camera in m_cinemachineCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}
