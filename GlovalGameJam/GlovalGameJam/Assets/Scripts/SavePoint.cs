using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoints : MonoBehaviour
{
    public GameObject manager;
    private void OnTriggerEnter(Collider other)
    {
        manager.GetComponent<GameManager>().current_restart_point = this.gameObject;
        Debug.Log("saved");
        Debug.Log(manager.GetComponent<GameManager>().current_restart_point);
    }
}
