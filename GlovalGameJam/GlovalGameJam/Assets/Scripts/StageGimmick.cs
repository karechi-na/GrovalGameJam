using UnityEngine;

public class StageGimmick : MonoBehaviour
{

    [Header("プレイヤー")]
    [SerializeField] private GameObject player;

    [Header("プレイヤーの座標を取得")]
    [SerializeField] private Transform playerTransform;

    [Header("急流域の開始座標、終了地点の座標")]
    public Vector3 rapidsPositionStart;
    public Vector3 rapidsPositioEnd;

    [Header("宝箱を持っているかの判別用変数")]
    public bool havingChest = false;

    [Header("温水域の開始座標、終了座標")]
    public Vector3 warmwaterPositionStart;
    public Vector3 warmwaterPositionEnd;

    [Header("冷水域の開始座標、終了座標")]
    public Vector3 coldWaterPositionStart;
    public Vector3 coldWaterPositionEnd;

    [Header("汚水域の開始座標、終了座標")]
    public Vector3 sewageAreaPositionStart;
    public Vector3 sewageAreaPositionEnd;

    [Header("プレイヤーのrigidbody")]
    [SerializeField] private Rigidbody playerRb;

    [Header("急流エリアでのVector3の各方向への力の追加")]
    [SerializeField] private Vector3 rapidsForce = new Vector3();

    [Header("宝箱を持っている時の減速値")]
    [SerializeField] private Vector3 havingChestSpeed = new Vector3();

    //ギミックで変化した速度を戻す変数
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
    /// ギミックのエリアに入った科かを確認する
    /// </summary>
    private void OnTriggerEnter(Collider player)
    {
        //急流エリアに入った時呼ばれる
        if(playerTransform.position == rapidsPositionStart)
        {
            RapidsGimmick();
        }

        //宝箱を持っている間実行
        if(havingChest)
        {
            TreasureChestGimmick();
        }

        //温水エリアに入った時呼ばれる
        if(playerTransform.position == warmwaterPositionStart)
        {
            WarmWaterGimmick();
        }

        //冷水エリアに入ったとき呼ばれる
        if(playerTransform.position == coldWaterPositionStart)
        {
            ColdWaterGommic();
        }

        //汚水エリアに入った時呼ばれる
        if(playerTransform.position == sewageAreaPositionStart)
        {
            SewageAreaGimmick();
        }

    }

    /// <summary>
    /// 急流に入った際のギミック
    /// </summary>
    public void RapidsGimmick()
    {
        playerRb.AddForce(rapidsForce);

        //急流エリアを抜けた時実行
        if(playerTransform.position == rapidsPositioEnd)
        {
            playerRb.AddForce(speedReset);
        }
    }

    /// <summary>
    /// 宝箱を取ったときに発生するギミック
    /// </summary>
    public void TreasureChestGimmick()
    {
        playerRb.AddForce(havingChestSpeed);

        //宝箱を手放すと実行
        if(havingChest == false)
        {
            playerRb.AddForce(speedReset);
        }
    }


    /// <summary>
    /// 温水域内のギミック
    /// </summary>
    public void WarmWaterGimmick()
    {

        //温水域を抜けると実行
        if(playerTransform.position == warmwaterPositionEnd)
        {

        }
    }

    /// <summary>
    /// 冷水域内のギミック
    /// </summary>
    public void ColdWaterGommic()
    {

        //冷水域を抜けると実行
        if (playerTransform.position == coldWaterPositionEnd)
        {

        }
    }

    /// <summary>
    /// 汚水域内のギミック
    /// </summary>
    public void SewageAreaGimmick()
    {

        //汚水域を抜けると実行
        if(playerTransform.position == sewageAreaPositionEnd)
        {

        }
    }
}
