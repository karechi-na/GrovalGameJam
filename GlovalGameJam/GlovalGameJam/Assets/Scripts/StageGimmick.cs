using UnityEngine;
using System.Collections;

public class StageGimmick : MonoBehaviour
{

    [Header("プレイヤー")]
    [SerializeField] private GameObject player;

    [Header("プレイヤーの座標を取得")]
    [SerializeField] private Transform playerTransform;

    [Header("温水域内での生成数を増やすため")]
    [SerializeField] private BubbleFactory bubbleFactory;

    [Header("汚水域")]
    [SerializeField] private GameObject sewage;

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

    [Header("bubble生成までの時間を遅らせる：コンマ秒指定可能")]
    [SerializeField] private float waitTime = 0.0f;

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
            ColdWaterGimmick();
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
        //さらに力をかけスピードをあげる
        playerRb.AddForce(rapidsForce);

        //急流エリアを抜けた時実行
        if(playerTransform.position == rapidsPositioEnd)
        {
            //追加した力を消し、スピードをリセット
            playerRb.AddForce(speedReset);
        }
    }

    /// <summary>
    /// 宝箱を取ったときに発生するギミック
    /// </summary>
    public void TreasureChestGimmick()
    {
        //スピードを落とす
        playerRb.AddForce(-havingChestSpeed);

        //宝箱を手放すと実行
        if(havingChest == false)
        {
            //落ちたスピードをリセット
            playerRb.AddForce(speedReset);
        }
    }


    /// <summary>
    /// 温水域内のギミック
    /// </summary>
    public void WarmWaterGimmick()
    {
        //域内でクリックされた時の生成数を増やす
        for(; ; )
        {
            if (Input.GetMouseButtonDown(1) && !bubbleFactory.m_isbubbleCountLimit)
            {
                bubbleFactory.SpawnSphere();
            }

            //温水域を抜けると実行
            if (playerTransform.position == warmwaterPositionEnd)
            {
                break;
            }
        }
        
    }

    /// <summary>
    /// 冷水域内のギミックを呼び出すメソッド
    /// </summary>
    public void ColdWaterGimmick()
    {
        //生成を遅らせる
        for(; ; )
        {
            if(Input.GetMouseButtonDown(1) && !bubbleFactory.m_isbubbleCountLimit)
            {
                StartCoroutine(ColdWaterGommic());

                bubbleFactory.SpawnSphere();
            }

            //冷水域を抜けると実行
            if (playerTransform.position == coldWaterPositionEnd)
            {
                break;
            }
        }

        
    }
    /// <summary>
    /// 冷水域内のギミック
    /// </summary>
    public IEnumerator ColdWaterGommic()
    {
        //waitTime秒待機
        yield return new WaitForSeconds(waitTime);
    }

    /// <summary>
    /// 汚水域内のギミック
    /// </summary>
    public void SewageAreaGimmick()
    {
        //表示する
        sewage.SetActive(true);

        //汚水域を抜けると実行
        if(playerTransform.position == sewageAreaPositionEnd)
        {
            //非表示にする
            sewage.SetActive(false);
        }
    }
}
