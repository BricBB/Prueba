using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    private float timeRemaining = 60.0f;
    private int score = 0;

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }
        timerText.text = "Time: " + Mathf.Round(timeRemaining);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
