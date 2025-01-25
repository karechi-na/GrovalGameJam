using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private BubbleFactory m_bubbleFactory = null;

    [SerializeField] private Vector3 m_initRotation = Vector3.zero;

    [SerializeField]
    private float m_horizontalSpeed = 0;

    [SerializeField]
    private float m_verticalSpeed = 0;

    [SerializeField]
    private float m_liftForce = 0;

    [SerializeField]
    private float m_downForce = 0;

    [SerializeField]
    private float m_downDistance = 0;

    [SerializeField]
    private float m_upDistance = 0;

    private Rigidbody m_playerRb = null;

    Vector3 m_downBasicPos = Vector3.zero;

    Vector3 m_downDesirePos = Vector3.zero;

    Vector3 m_upBasicPos = Vector3.zero;

    Vector3 m_upDesirePos = Vector3.zero;

    private bool m_isDown = false;

    private bool m_isDownBasicPos = false;

    private bool m_isUpBasicPos = false;

    private bool m_isUp = false;

    public bool IsDown {  get { return m_isDown; } }

    public bool IsUp {  get { return m_isUp; } }

    // Start is called before the first frame update
    void Start()
    {
        m_playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        HolizontalMove();
        VerticalMove();

        if (m_isUp)
        {
            Up();
            Buoyancy();
        }
        if (m_isDown)
        {
            Down();
            DownMove();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;

            // XとYを0にしてZ軸の回転を保持
            transform.rotation = Quaternion.Euler(m_initRotation);
        }
    }

    private void HolizontalMove()
    {
        float move = Input.GetAxis("Horizontal"); // A/Dキーまたは←/→キー
        m_playerRb.velocity = new Vector3(move * m_horizontalSpeed, m_playerRb.velocity.y, m_playerRb.velocity.z);
    }

    private void VerticalMove()
    {
        float move = Input.GetAxis("Vertical");
        m_playerRb.velocity = new Vector3(m_playerRb.velocity.x, m_playerRb.velocity.y, move * m_verticalSpeed);
    }

    private void Down()
    {
        m_playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        m_playerRb.useGravity = false;
        if (!m_isDownBasicPos)
        {
            m_downBasicPos = this.transform.position;
            m_isDownBasicPos = true;
            m_downDesirePos = m_downBasicPos;
            m_downDesirePos.y -= m_downDistance;
        }

        Vector3 currentPos = this.transform.position;

        if (Mathf.Abs(m_downBasicPos.y - currentPos.y) > m_downDistance)
        {
            m_isDown = false;
            m_isDownBasicPos = false;
            m_playerRb.constraints |= RigidbodyConstraints.FreezePositionY;
            m_playerRb.useGravity = true;
        }
    }

    private void Up()
    {
        m_playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        m_playerRb.useGravity = false;
        if (!m_isUpBasicPos)
        {
            m_upBasicPos = this.transform.position;
            m_isUpBasicPos = true;
            m_upDesirePos = m_upBasicPos;
            m_upDesirePos.y += m_upDistance;
        }

        Vector3 currentPos = this.transform.position;

        if (Mathf.Abs(m_upBasicPos.y - currentPos.y) > m_upDistance)
        {
            m_isUp = false;
            m_isUpBasicPos = false;
            m_playerRb.constraints |= RigidbodyConstraints.FreezePositionY;
            m_playerRb.useGravity = true;
        }

    }

    private void DownMove()
    {
        m_playerRb.AddForce(Vector3.down * m_downForce * Time.deltaTime);
    }

    private void Buoyancy()
    {
        m_playerRb.AddForce(Vector3.up * m_liftForce * Time.deltaTime);
    }


    public void SetDownOnLeftClick()
    {
        m_isUp = false;
        m_isUpBasicPos = false;
        m_isDown = true;
    }

    public void SetUpOnRightClick()
    {
        m_isDown = false;
        m_isDownBasicPos = false;
        m_isUp = true;
    }

    private void InitRotation()
    {

    }
}