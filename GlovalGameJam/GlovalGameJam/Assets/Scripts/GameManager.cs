using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int available_bubble = 10;
    private int max_available_bubble;
    private int current_bubble = 5;
    public TextMeshProUGUI available_txt;
    public TextMeshProUGUI current_txt;
    public GameObject bubble;
    public GameObject all_restart_points;
    public GameObject current_restart_point;
    private GameObject fail_text;
    // Start is called before the first frame update
    void Start()
    {
        fail_text = GameObject.Find("Fail Text (TMP)");
        fail_text.SetActive(false);
        max_available_bubble = available_bubble;
        current_restart_point = all_restart_points.transform.GetChild(0).gameObject;
        available_txt.text = "Available Bubble: " + available_bubble.ToString();
        current_txt.text = "Current Bubble: " + current_bubble.ToString() + "/" + "20"; //current/limit
        current_bubble = bubble.GetComponent<BubbleFactory>().BubbleCount;
        Debug.Log(current_bubble);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            available_bubble -= 1;
            available_txt.text = "Available Bubble: " + available_bubble.ToString();
            current_bubble = bubble.GetComponent<BubbleFactory>().BubbleCount;
            Debug.Log(current_bubble);
        }
        if (available_bubble <= 0){
            Debug.Log("Game Over");
            fail_text.SetActive(true);
            StartCoroutine(waiting());
            initiate();
            //game over
        }
    }

    private void initiate() {
        GameObject player = GameObject.Find("Player");
        player.transform.position = current_restart_point.transform.position;
        player.transform.rotation = current_restart_point.transform.rotation;
        available_bubble = max_available_bubble;
        available_txt.text = "Available Bubble: " + available_bubble.ToString();
        // reset the current bubble around player   
    }

    private IEnumerator waiting()
    {
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + 3;
        while (Time.realtimeSinceStartup < pauseEndTime) {
            yield return 0;
        }
        Time.timeScale = 1;
        fail_text.SetActive(false);
    }
}
