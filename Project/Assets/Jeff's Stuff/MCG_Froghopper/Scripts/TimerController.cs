using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float timerDuration = 3f; // Duration of the timer in seconds
    private float timeRemaining;
    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro text component

    void Start()
    {
        timeRemaining = timerDuration;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                timeRemaining = 0;
            }
            UpdateTimerDisplay(timeRemaining);
        }
        else
        {
            timerText.text = "Time's up!";
            Time.timeScale = 0;
        }
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = time.ToString("F2"); // Display time with 2 decimal places
    }
}
