using UnityEngine;

public class Goal : MonoBehaviour
{
    //このスクリプトをOnTriggerのゲームオブジェクトにアタッチしてください。
    private void OnTriggerEnter(Collider other)
    {
        LeachGoal();
    }

    public bool LeachGoal()
    {
        return true;
    }
}
