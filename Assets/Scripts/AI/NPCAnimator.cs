using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    private Animator m_animator;
    private Vector3 m_lastPosition;
    private Transform m_thisTransform;

    private void Awake()
    {
        m_thisTransform = transform;
        m_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        m_lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 thisPosition = m_thisTransform.position;
        float speed = Vector3.Distance(m_lastPosition, thisPosition) / Time.deltaTime;
        if (speed > 2)
        {
            m_animator.SetBool("Walking", true);
        }
        else
        {
            m_animator.SetBool("Walking", false);
        }

        m_lastPosition = thisPosition;

    }

}
