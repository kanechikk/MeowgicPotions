using UnityEngine;

public class CouldronColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coudron activated");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Couldron stoped");
    }
}
