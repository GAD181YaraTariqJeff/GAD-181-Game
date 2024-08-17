using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float guideDuration = 3f; // Duration for the guide to be displayed
    public TextMeshProUGUI guideText; // Reference to the guide TextMesh Pro component

    public float timerDuration = 3f; // Duration of the timer in seconds
    private float timeRemaining;
    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro text component

    void Start()
    {
        StartCoroutine(DisplayGuideAndStartTimer());
    }

    IEnumerator DisplayGuideAndStartTimer()
    {
        // Display the guide
        guideText.gameObject.SetActive(true);
        yield return new WaitForSeconds(guideDuration);

        // Hide the guide and start the timer
        guideText.gameObject.SetActive(false);
        timeRemaining = timerDuration;

        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                timeRemaining = 0;
            }
            UpdateTimerDisplay(timeRemaining);
            yield return null;
        }

        timerText.text = "Time's up!";
        Time.timeScale = 0;
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = time.ToString("F2"); // Display time with 2 decimal places
    }
}
