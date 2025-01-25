
using UnityEngine;

public class BubbeMover : MonoBehaviour
{
    [SerializeField]
    private Transform m_playerTransform = null;

    [SerializeField]
    private float m_pullForce = 0.0f;

    [SerializeField]
    private float m_bubbleDistance = 0;

    private Vector3 m_thisTransform = Vector3.zero;

    Rigidbody m_thisrb = null;



    void Start()
    {
        m_thisrb = GetComponent<Rigidbody>();
        m_playerTransform = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Transform>();
    }

    void Update()
    {
        ConstantBubbleDistance();
    }

    void ConstantBubbleDistance()
    {
        float distance = Vector3.Distance(m_thisTransform, m_playerTransform.position);

        Vector3 pullVector = (m_thisTransform - m_playerTransform.position).normalized;
        if (distance > m_bubbleDistance)
        {
            m_thisrb.velocity = Vector3.zero;
            m_thisrb.AddForce(pullVector * m_pullForce);
        }
    }


}
