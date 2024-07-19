using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AtrTimer : MonoBehaviour
{
    public float duration = 15f; // Duration of the timer in seconds
    private float remaining;
    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro text component

    void Start()
    {
        remaining = duration;
    }

    void Update()
    {
        if (remaining > 0)
        {
            remaining -= Time.deltaTime;
            if (remaining < 0)
            {
                remaining = 0;
            }
            UpdateTimerDisplay(remaining);
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
