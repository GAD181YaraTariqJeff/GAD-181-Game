using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameDuration = 5f; // Duration of the game in seconds
    private float remainingTime;
    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro text component
    public GameObject loseTextObject; // Reference to the lose text object

    void Start()
    {
        remainingTime = gameDuration;
        loseTextObject.SetActive(false); // Hide the lose message at the start
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0)
            {
                remainingTime = 0;
            }
            UpdateTimerDisplay(remainingTime);
        }
        else
        {
            loseTextObject.SetActive(true); // Show the lose message
            Time.timeScale = 0; // Pause the game
        }
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = time.ToString("F2"); // Display time with 2 decimal places
    }
}
