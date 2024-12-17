using UnityEngine;

public class CouldronColliderHandler : MonoBehaviour
{
    public GameObject brewingUI;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coudron activated");
        brewingUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Couldron stoped");
    }
}
