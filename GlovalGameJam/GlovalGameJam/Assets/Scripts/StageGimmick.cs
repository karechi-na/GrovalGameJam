using UnityEngine;

public class StageGimmick : MonoBehaviour
{

    [Header("�v���C���[")]
    [SerializeField] private GameObject player;

    [Header("�v���C���[�̍��W���擾")]
    [SerializeField] private Transform playerTransform;

    [Header("�}����̊J�n���W�A�I���n�_�̍��W")]
    public Vector3 rapidsPositionStart;
    public Vector3 rapidsPositioEnd;

    [Header("�󔠂������Ă��邩�̔��ʗp�ϐ�")]
    public bool havingChest = false;

    [Header("������̊J�n���W�A�I�����W")]
    public Vector3 warmwaterPositionStart;
    public Vector3 warmwaterPositionEnd;

    [Header("�␅��̊J�n���W�A�I�����W")]
    public Vector3 coldWaterPositionStart;
    public Vector3 coldWaterPositionEnd;

    [Header("������̊J�n���W�A�I�����W")]
    public Vector3 sewageAreaPositionStart;
    public Vector3 sewageAreaPositionEnd;

    [Header("�v���C���[��rigidbody")]
    [SerializeField] private Rigidbody playerRb;

    [Header("�}���G���A�ł�Vector3�̊e�����ւ̗͂̒ǉ�")]
    [SerializeField] private Vector3 rapidsForce = new Vector3();

    [Header("�󔠂������Ă��鎞�̌����l")]
    [SerializeField] private Vector3 havingChestSpeed = new Vector3();

    //�M�~�b�N�ŕω��������x��߂��ϐ�
    private Vector3 speedReset = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// �M�~�b�N�̃G���A�ɓ������Ȃ����m�F����
    /// </summary>
    private void OnTriggerEnter(Collider player)
    {
        //�}���G���A�ɓ��������Ă΂��
        if(playerTransform.position == rapidsPositionStart)
        {
            RapidsGimmick();
        }

        //�󔠂������Ă���Ԏ��s
        if(havingChest)
        {
            TreasureChestGimmick();
        }

        //�����G���A�ɓ��������Ă΂��
        if(playerTransform.position == warmwaterPositionStart)
        {
            WarmWaterGimmick();
        }

        //�␅�G���A�ɓ������Ƃ��Ă΂��
        if(playerTransform.position == coldWaterPositionStart)
        {
            ColdWaterGommic();
        }

        //�����G���A�ɓ��������Ă΂��
        if(playerTransform.position == sewageAreaPositionStart)
        {
            SewageAreaGimmick();
        }

    }

    /// <summary>
    /// �}���ɓ������ۂ̃M�~�b�N
    /// </summary>
    public void RapidsGimmick()
    {
        playerRb.AddForce(rapidsForce);

        //�}���G���A�𔲂��������s
        if(playerTransform.position == rapidsPositioEnd)
        {
            playerRb.AddForce(speedReset);
        }
    }

    /// <summary>
    /// �󔠂�������Ƃ��ɔ�������M�~�b�N
    /// </summary>
    public void TreasureChestGimmick()
    {
        playerRb.AddForce(havingChestSpeed);

        //�󔠂�������Ǝ��s
        if(havingChest == false)
        {
            playerRb.AddForce(speedReset);
        }
    }


    /// <summary>
    /// ��������̃M�~�b�N
    /// </summary>
    public void WarmWaterGimmick()
    {

        //������𔲂���Ǝ��s
        if(playerTransform.position == warmwaterPositionEnd)
        {

        }
    }

    /// <summary>
    /// �␅����̃M�~�b�N
    /// </summary>
    public void ColdWaterGommic()
    {

        //�␅��𔲂���Ǝ��s
        if (playerTransform.position == coldWaterPositionEnd)
        {

        }
    }

    /// <summary>
    /// ��������̃M�~�b�N
    /// </summary>
    public void SewageAreaGimmick()
    {

        //������𔲂���Ǝ��s
        if(playerTransform.position == sewageAreaPositionEnd)
        {

        }
    }
}
