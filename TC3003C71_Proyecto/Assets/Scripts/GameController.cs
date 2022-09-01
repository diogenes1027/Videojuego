using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text lifeText;
    public Text timeText;

    float time = 0;

    public bool timerIsRunning = true;

    // public Player player;
    

    // Update is called once per frame
    void Update()
    {
        // lifeText.text = "Life remaining: " + player.life;

        if (timerIsRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
