using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool m_goal = false;

    public bool isGoal {  get { return m_goal; } }
    private void OnTriggerEnter(Collider other)
    {
            LeachGoal(other.gameObject);
    }

    public void LeachGoal(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            m_goal = true;
        }
    }
}
