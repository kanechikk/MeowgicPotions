using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    private float speedMove = 5f;
    [SerializeField]
    private float speedRotation = 5f;

    public void Move(Vector2 dir)
    {

    }
}
