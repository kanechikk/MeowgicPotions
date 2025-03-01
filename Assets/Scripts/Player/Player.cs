using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    private CharacterController m_characterController;
    [SerializeField]
    private float m_speedMove = 5f;
    [SerializeField]
    private float m_speedRotation = 800f;
    [SerializeField]
    private float m_yVelocity = 1f;

    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 input) // Метод передачи импута в SimpleMove и вращения персонажа в направлении движения
    {
        if (m_characterController)
        {
            Vector3 dir = new Vector3(input.x, m_yVelocity * -1, input.y);
            m_characterController.Move(dir * m_speedMove * Time.deltaTime);

            if (input != Vector2.zero)
            {
                m_animator.SetBool("Walking", true);

                GameManager.instance.audioManager.PlaySFXWalking(false);
            }
            else
            {
                m_animator.SetBool("Walking", false);

                GameManager.instance.audioManager.PlaySFXWalking(true);
            }

            if (input.sqrMagnitude > 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                Quaternion.LookRotation(new Vector3(input.x, 0f, input.y)), m_speedRotation * Time.deltaTime);
            }
        }
    }
}
