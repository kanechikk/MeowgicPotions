using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door activated");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Door stoped");
    }
}
