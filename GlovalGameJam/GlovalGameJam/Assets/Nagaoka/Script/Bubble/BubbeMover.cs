
using TMPro;
using UnityEngine;

public class BubbeMover : MonoBehaviour
{
    [SerializeField]
    private Transform m_playerTransform = null;

    [SerializeField]
    private float m_pullForce = 0.0f;

    [SerializeField]
    private float m_bubbleDistance = 0;

    [SerializeField]  private Vector3 offset;

    [SerializeField] 
    private Vector3 max = Vector3.zero;

    [SerializeField]
    private Vector3 min = Vector3.zero;

    [SerializeField]
    private Vector3 a = Vector3.zero;

    private Vector3 m_thisTransform = Vector3.zero;

    Rigidbody m_thisrb = null;

    private bool isKinema = false;

    PlayerMover m_playerMover = null;

    void Start()
    {
        m_thisrb = GetComponent<Rigidbody>();
        m_playerTransform = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Transform>();
        m_playerMover = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<PlayerMover>();
    }

    void Update()
    {
        
        if (Distance())
        {
            aiueo();
        }
        
        //transform.position = m_playerTransform.position + offset;
        //ConstantBubbleDistance();

    }

    void aiueo()
    {
        Vector3 desire = Vector3.zero;
        desire.x = Clamp(this.transform.position.x, m_playerTransform.position.x - m_bubbleDistance, m_playerTransform.position.x + m_bubbleDistance);
        desire.y = Clamp(this.transform.position.y, m_playerTransform.position.y - m_bubbleDistance, m_playerTransform.position.x + m_bubbleDistance);
        desire.z = Clamp(this.transform.position.z, m_playerTransform.position.z - m_bubbleDistance, m_playerTransform.position.z + m_bubbleDistance);

        m_thisrb.AddForce(desire);
        //this.transform.position = desire.normalized;
    }

    float Clamp(float value,float min,float max)
    {
        if(value < min)
        {
            return min;
        }
        if (value > max)
        {
            return max;
        }

        
        return value;
    }

    bool Distance()
    {
        float distance = Vector3.Distance(this.transform.position, m_playerTransform.position);
        if (distance > m_bubbleDistance)
        {
            return true;
        }
            return false;
    }

    //void ConstantBubbleDistance()
    //{
    //    if(isKinema)
    //    {
    //        return;
    //    }
    //    float distance = Vector3.Distance(this.transform.position, m_playerTransform.position);

    //    Vector3 pullVector = (this.transform.position - m_playerTransform.position).normalized;
    //    if (distance > m_bubbleDistance)
    //    {
    //        m_thisrb.velocity = Vector3.zero;
    //        m_thisrb.AddForce(pullVector * m_pullForce);
    //    }
    //    if (distance <= m_bubbleDistance)
    //    {
    //        m_thisrb.velocity = Vector3.zero;
    //    }
    //}

    //void Kinematic()
    //{
    //    if (m_playerMover.IsDown || m_playerMover.IsUp)
    //    {
    //        isKinema = true;
    //        m_thisrb.isKinematic = true;
    //    }
    //    isKinema = false;
    //    m_thisrb.isKinematic = true;

    //}
}
