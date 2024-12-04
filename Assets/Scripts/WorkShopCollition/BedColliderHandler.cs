using UnityEngine;

public class BedColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bed activated");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Bed stoped");
    }
}
