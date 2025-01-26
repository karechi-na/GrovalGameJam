using TMPro;
using UnityEngine;

public class GoalText : MonoBehaviour
{
    [SerializeField]
    private Goal m_goalSensor = null;

    [SerializeField]
    private TextMeshProUGUI m_goalTextUI = null;

    [SerializeField]
    private string m_goalText = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_goalSensor.isGoal)
        {
            m_goalTextUI.text = m_goalText;
        }
    }
}
