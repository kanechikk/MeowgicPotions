using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController m_characterController;
    [SerializeField]
    private float m_speedMove = 5f;
    [SerializeField]
    private float m_speedRotation = 800f;

    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 input) // Метод передачи импута в SimpleMove и вращения персонажа в направлении движения
    {
        if (m_characterController)
        {
            Vector3 dir = new Vector3(input.x, 0f, input.y);
            m_characterController.SimpleMove(dir * m_speedMove);

            if (input.sqrMagnitude > 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), m_speedRotation * Time.deltaTime);
                Debug.Log(transform.rotation);
            }
        }
    }
}
