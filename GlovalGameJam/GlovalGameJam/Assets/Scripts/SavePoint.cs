using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoints : MonoBehaviour
{
    public GameObject manager;
    private void OnTriggerEnter(Collider other)
    {
        manager.GetComponent<GameManager>().current_restart_point = this.gameObject;
        manager.GetComponent<GameManager>().available_bubble = manager.GetComponent<GameManager>().max_available_bubble;
        manager.GetComponent<GameManager>().available_txt.text = "Available Bubble: " + manager.GetComponent<GameManager>().available_bubble.ToString();
        Debug.Log("saved");
        Debug.Log(manager.GetComponent<GameManager>().current_restart_point);
    }
}
