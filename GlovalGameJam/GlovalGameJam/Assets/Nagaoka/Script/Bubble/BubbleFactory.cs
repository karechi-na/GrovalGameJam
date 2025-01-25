using System.Collections.Generic;
using UnityEngine;

public class BubbleFactory : MonoBehaviour
{
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

    [SerializeField]
    private List<GameObject> m_bubbleList = new List<GameObject>();

    private PlayerMover m_playerMover = null;

    int m_bubbleCount = 0;

    bool m_isbubbleCountLimit = false;

    public int BubbleCount { get { return m_bubbleList.Count; } }

    public bool IsBubbleCountLimit { get { return m_isbubbleCountLimit; } }

    private void Start()
    {
        m_playerMover = GetComponentInParent<PlayerMover>();

        for (int i = 0; i < m_initBubble; i++)
        {
            SpawnSphere();
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

    void SpawnSphere()
    {
        GameObject bubble = Instantiate(m_bubblePrefab, m_playerTransform.position, Quaternion.identity);

        m_bubbleList.Add(bubble);

        bubble.transform.SetParent(this.transform);

        bubble.transform.localPosition = new Vector3(0, 1, 0);
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

                Destroy(bubble); // オブジェクトを削除

                return; // 1つだけ削除したら終了
            }
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
}
