using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGimmick : MonoBehaviour
{
    //[Header("温水ギミック")]
    //[SerializeField] private GameObject warmWater;

    // Start is called before the first frame update

    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        
    }

    /// <summary>
    /// 急流に入った際のギミック
    /// </summary>
    public void RapidsGimmick()
    {
        
    }

    /// <summary>
    /// 宝箱を取ったときに発生するギミック
    /// </summary>
    public void TreasureChestGimmick()
    {

    }


    /// <summary>
    /// 温水域内のギミック
    /// </summary>
    public void WarmWaterGimmick()
    {

    }

    /// <summary>
    /// 冷水域内のギミック
    /// </summary>
    public void ColdWaterGommic()
    {

    }
}
