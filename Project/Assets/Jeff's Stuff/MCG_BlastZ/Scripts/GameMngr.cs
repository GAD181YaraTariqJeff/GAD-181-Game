using UnityEngine;
using System.Collections;
using TMPro; 

public class GameMngr : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints; // Array of spawn points for targets
    public int totalTargets = 5;
    public float timeLimit = 10f; // Time limit in seconds
    public TextMeshProUGUI timerText; // TMP component to display the timer
                                      // public TextMeshProUGUI targetCountText; // TMP component to display the remaining target count

    public TextMeshProUGUI guideText; // Reference to the guide text UI element
    public float guideDisplayTime = 3f; // Time in seconds to display the guide before starting the game

    private int targetsShot = 0;
    private int targetsRemaining;
    private float timer;

    void Start()
    {
        // Start the game with a guide display
        StartCoroutine(DisplayGuideAndStartGame());
        // Start the timer
        timer = timeLimit;
   
       
   
    }
    IEnumerator DisplayGuideAndStartGame()
    {
        // Ensure the guide text is enabled at the start
        guideText.gameObject.SetActive(true);

        // Wait for the specified display time
        yield return new WaitForSeconds(guideDisplayTime);

        // Hide the guide text
        guideText.gameObject.SetActive(false);

        // Initialize game variables
        timer = timeLimit;
        targetsRemaining = totalTargets;

        // Spawn targets
        SpawnTargets();
    }
    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Clamp timer to 0
        timer = Mathf.Max(timer, 0);

        // Update the timer display
        UpdateTimerDisplay();

        // Check if time has run out
        if (timer <= 0)
        {
            EndGame(false); // Time is up, player loses
        }
    }

    public void TargetShot()
    {
        targetsShot++;
        targetsRemaining--;

        // Update the target count display
        //UpdateTargetCountDisplay();

        // Check if all targets have been shot
        if (targetsRemaining <= 0)
        {
            EndGame(true); // All targets shot within time limit, player wins
        }
    }

    void SpawnTargets()
    {
        for (int i = 0; i < totalTargets; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    void EndGame(bool won)
    {
        if (won)
        {
           Debug.Log ("You Win!");
        }
        else
        {
            Debug.Log("You Lose!");
        }

        // Optional: Disable further player actions or pause the game
        Time.timeScale = 0; // Pauses the game
    }

    void UpdateTimerDisplay()
    {
        // Update the timer text with the remaining time
        timerText.text = $"Time: {timer:F1}"; // F1 formats the timer to 1 decimal place
    }

   /* void UpdateTargetCountDisplay()
    {
        // Update the target count text with the number of remaining targets
        targetCountText.text = $"Targets Left: {targetsRemaining}";
    }*/
}
