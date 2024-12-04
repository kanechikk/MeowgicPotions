using UnityEngine;

public class SeedTableColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SeedTable activated");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("SeedTable stoped");
    }
}
