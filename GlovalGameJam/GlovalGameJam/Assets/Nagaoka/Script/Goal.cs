using UnityEngine;

public class Goal : MonoBehaviour
{
    //���̃X�N���v�g��OnTrigger�̃Q�[���I�u�W�F�N�g�ɃA�^�b�`���Ă��������B
    private void OnTriggerEnter(Collider other)
    {
        LeachGoal();
    }

    public bool LeachGoal()
    {
        return true;
    }
}
