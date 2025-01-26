using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleNumChange : MonoBehaviour
{
    public GameObject manager;
    public int bubbleNumChange = 5;
    public int changeDirection = 1; // 1 or -1
    private int cnt=0;
    public void OnTriggerEnter(Collider other)
    {
        if (cnt <= 0) {
            if (changeDirection == -1 && manager.GetComponent<GameManager>().available_bubble <= bubbleNumChange * changeDirection)
            {
                manager.GetComponent<GameManager>().available_bubble = 1;
            }
            else
            {
                manager.GetComponent<GameManager>().available_bubble += bubbleNumChange * changeDirection;
            }
            manager.GetComponent<GameManager>().available_txt.text = "Available Bubble: " + manager.GetComponent<GameManager>().available_bubble.ToString();
            cnt++;
            Destroy(this.gameObject);
        }
    }
}
