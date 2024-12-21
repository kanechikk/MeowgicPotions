using UnityEngine;

public class CouldronColliderHandler : MonoBehaviour
{
    public GameObject brewingState;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coudron activated");
        brewingState.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Couldron stoped");
    }
}
