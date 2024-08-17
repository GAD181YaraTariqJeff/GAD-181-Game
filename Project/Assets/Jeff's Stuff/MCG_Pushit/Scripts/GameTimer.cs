using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameDuration = 10f; // Duration of the game in seconds
    private float remainingTime;
    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro text component
    public TextMeshProUGUI guideText; // Reference to the guide text UI element
    public float guideDisplayTime = 3f; // Time in seconds to display the guide before starting the game

    void Start()
    {
        guideText.gameObject.SetActive(true); // Show the guide text
       
        StartCoroutine(DisplayGuideAndStartTimer()); // Start coroutine to handle guide and timer
    }

    IEnumerator DisplayGuideAndStartTimer()
    {
        // Wait for the specified display time
        yield return new WaitForSeconds(guideDisplayTime);

        // Hide the guide text
        guideText.gameObject.SetActive(false);

        // Initialize timer
        remainingTime = gameDuration;
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
            Time.timeScale = 1; // Pause the game
        }
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = time.ToString("F2"); // Display time with 2 decimal places
    }
}
