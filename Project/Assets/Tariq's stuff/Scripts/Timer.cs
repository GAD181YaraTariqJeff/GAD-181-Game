using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float gameTime;
    public Text gameText;
    public float guideDuration = 3f; // Duration for the guide to be displayed
    public Text guideText; // Reference to the guide text UI element
    private bool isGameRunning = false; // Track whether the game has started

    void Start()
    {
        StartCoroutine(DisplayGuideAndStartTimer());
    }

    IEnumerator DisplayGuideAndStartTimer()
    {
        // Display the guide
        guideText.gameObject.SetActive(true);
        Time.timeScale = 0f; // Pause the game while the guide is displaying
        yield return new WaitForSecondsRealtime(guideDuration); // Wait for the guide to disappear

        // Hide the guide and start the game timer
        guideText.gameObject.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isGameRunning = true;
    }
    void Update()
    {
        if (isGameRunning)
        {
            gameTime -= Time.deltaTime;
            if (gameTime < 1)
            {
                gameTime = 0;
                Time.timeScale = 0f;
                Debug.Log("Game over!");
            }
            gameText.text = gameTime.ToString("F2"); // Display time with 2 decimal places
        }
    }


}
