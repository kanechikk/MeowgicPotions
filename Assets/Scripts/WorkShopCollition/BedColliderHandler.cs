using UnityEngine;

public class BedColliderHandler : MonoBehaviour
{
    [SerializeField] private DayTimeManager daytimeManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bed activated");
        daytimeManager.DayAdd();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Bed stoped");
    }
}
