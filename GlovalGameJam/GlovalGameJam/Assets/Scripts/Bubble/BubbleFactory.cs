using System.Collections.Generic;
using UnityEngine;

public class BubbleFactory : MonoBehaviour
{
    [SerializeField]
    private EffectManager m_effectManager = null;

    [SerializeField]
    private SEManager m_SEManager = null;

    [SerializeField]
    private GameObject m_bubblePrefab = null;

    [SerializeField]
    private Transform m_playerTransform = null;

    [SerializeField]
    private int m_initBubble = 0;

    [SerializeField]
    private int m_bubbleCountLimit = 0;

    [SerializeField]
    private string bubbleTag = null;

    private List<GameObject> m_bubbleList = new List<GameObject>();

    private PlayerMover m_playerMover = null;

    int m_bubbleCount = 0;

    public bool m_isbubbleCountLimit = false;

   

    public int BubbleCount { get { return m_bubbleList.Count; } }

    public int BubbleCountLimit { get { return m_bubbleCountLimit; } }

    public bool IsBubbleCountLimit { get { return m_isbubbleCountLimit; } }

    private void Start()
    {
        m_playerMover = GetComponentInParent<PlayerMover>();

        for (int i = 0; i < m_initBubble; i++)
        {
            //SE鳴らしたくないのでSpawnSphereと同じ処理ベタ打ちしてます
            GameObject bubble = Instantiate(m_bubblePrefab, m_playerTransform.position, Quaternion.identity);

            m_bubbleList.Add(bubble);

            bubble.transform.SetParent(this.transform);

            bubble.transform.localPosition = new Vector3(0, 1, 0);
        }
    }

    void Update()
    {
        CheckBubbleLimit();

        if (Input.GetMouseButtonDown(1) && !m_isbubbleCountLimit) // 右クリック
        {
            m_playerMover.SetUpOnRightClick();
            SpawnSphere();
        }
        if (Input.GetMouseButtonDown(0) && m_bubbleList.Count > 0)//左クリック
        {
            m_playerMover.SetDownOnLeftClick();
            DestroySphere();
        }
    }

    public void SpawnSphere()
    {
        GameObject bubble = Instantiate(m_bubblePrefab, m_playerTransform.position, Quaternion.identity);

        m_bubbleList.Add(bubble);

        bubble.transform.SetParent(this.transform);

        bubble.transform.localPosition = new Vector3(0, 1, 0);

        m_SEManager.OnPlayOneShot(SEManager.SoundEffectName.BubbleCreate);
    }

    void DestroySphere()
    {
        for (int i = 0; i < m_bubbleList.Count; i++)
        {
            if (m_bubbleList[i] == null)
            {
                return;
            }

            GameObject bubble = m_bubbleList[i];

            if (bubble.CompareTag(bubbleTag))
            {
                // 見つかった場合、そのオブジェクトを削除
                m_bubbleList.RemoveAt(i); // リストから削除

                m_SEManager.OnPlayOneShot(SEManager.SoundEffectName.BubbleBreak);

                m_effectManager.OnPlayEffect(bubble.transform.position, EffectManager.EffectType.SubEmitterDeath);

                Destroy(bubble); // オブジェクトを削除

                return; // 1つだけ削除したら終了
            }
        }
    }

    public void DestroyAllSphere()
    {
        int iLimit = m_bubbleList.Count;
        for (int i = 0; i < iLimit; i++)
        {
            if (m_bubbleList[i] == null)
            {
                continue;
            }
            GameObject bubble = m_bubbleList[i];

            if (bubble.CompareTag(bubbleTag))
            {
                // 見つかった場合、そのオブジェクトを削除
                // リストから削除

                Destroy(bubble); // オブジェクトを削除
            }
        }
        m_bubbleList.Clear();
    }

    public void RespawnBubble()
    {
        for (int i = 0; i < m_initBubble; i++)
        {
            GameObject bubble = Instantiate(m_bubblePrefab, m_playerTransform.position, Quaternion.identity);

            m_bubbleList.Add(bubble);

            bubble.transform.SetParent(this.transform);

            bubble.transform.localPosition = new Vector3(0, 1, 0);
        }
    }

    public bool CheckBubbleLimit()
    {
        if (m_bubbleList.Count >= m_bubbleCountLimit)
        {
            m_isbubbleCountLimit = true;
            return true;
        }
        else
        {
            m_isbubbleCountLimit = false;
            return false;
        }
    }

    /// <summary>
    /// 初期バブル個数と現在の個数の差を返します。
    /// </summary>
    /// <returns></returns>
    public int BubbleTracker()
    {
        int bubbleGap = m_bubbleList.Count - m_initBubble;
        return bubbleGap;
    }
}
