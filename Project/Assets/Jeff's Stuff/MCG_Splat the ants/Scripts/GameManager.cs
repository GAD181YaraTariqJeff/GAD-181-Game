using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; // Add this directive

public class GameManager : MonoBehaviour
{
    public AntController antController;
    public UIManager uiManager;
    public float duration = 15f; // Duration of the timer in seconds
    private float remaining;
    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro text component
    private int scoreNumber = 0;
    [SerializeField] private GameObject gameGuideUI; // Reference to the Game Guide UI
    [SerializeField] private float guideDuration = 3f; // Duration for showing the guide


    /// <summary>
    /// In the start there will be checks so that we can identify if there are any missing components
    /// </summary>
    void Start()
    {
        StartCoroutine(ShowGuideAndStartGame()); // Start the guide and game timer sequence

        remaining = duration; // Initialize the timer

        GameObject antObject = GameObject.Find("Ant");
        if (antObject == null)
        {
            Debug.LogError("Ant GameObject not found");
        }
        else
        {
            antController = antObject.GetComponent<AntController>();
            if (antController == null)
            {
                Debug.LogError("AntController component not found on Ant GameObject");
            }
        }

        GameObject uiManagerObject = GameObject.Find("UIManager");
        if (uiManagerObject == null)
        {
            Debug.LogError("UIManager GameObject not found");
        }
        else
        {
            uiManager = uiManagerObject.GetComponent<UIManager>();
            if (uiManager == null)
            {
                Debug.LogError("UIManager component not found on UIManager GameObject");
            }
        }

        // If everything is found, proceed with initialization
        if (antController != null && uiManager != null)
        {
            uiManager.UpdateScore(scoreNumber);
            ResetAntPosition();
        }
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
            // Add any game over logic here if needed
        }

        if (antController != null && antController.transform.position.y < -4.35f)
        {
            ResetAntPosition();
        }
    }

    void ResetAntPosition()
    {
        antController.ResetPosition(new Vector3(Random.Range(-2.54f, 2.54f), Random.Range(-4.0f, 3.8f), 0));
    }

    void OnMouseDown()
    {
        scoreNumber++;
        uiManager.UpdateScore(scoreNumber);
        ResetAntPosition();
        antController.walkingSpeed += 0.01f;
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = time.ToString("F2"); // Display time with 2 decimal places
    }
    // Added the new coroutine for showing the guide and starting the game
    IEnumerator ShowGuideAndStartGame()
    {
        gameGuideUI.SetActive(true); // Show the guide UI
        Time.timeScale = 0f; // Pause the game
        yield return new WaitForSecondsRealtime(guideDuration); // Wait for the guide duration
        gameGuideUI.SetActive(false); // Hide the guide UI
        Time.timeScale = 1f; // Resume the game
        remaining = duration; // Initialize the timer after the guide disappears
    }

}
