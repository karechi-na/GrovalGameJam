using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavePoints : MonoBehaviour
{
    public GameObject manager;
    private bool sthEntered=false;
    private bool entered=false;
    public GameObject vfx_bubble;
    private void OnTriggerEnter(Collider other)
    {
        if (entered == false) {
            manager.GetComponent<GameManager>().current_restart_point = this.gameObject;
            manager.GetComponent<GameManager>().available_bubble = manager.GetComponent<GameManager>().max_available_bubble;
            manager.GetComponent<GameManager>().available_txt.text = "Available Bubble: " + manager.GetComponent<GameManager>().available_bubble.ToString();
            sthEntered = true;
            entered = true;
            Debug.Log("saved");
            Debug.Log(manager.GetComponent<GameManager>().current_restart_point);
        }
    }

    private void Update()
    {
        if (sthEntered == true) {
            Instantiate(vfx_bubble, this.gameObject.transform);
            sthEntered=false;
        }
    }
}
