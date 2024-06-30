using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;

    private float gameTime = 15f;
    private int score = 0;

    void Start()
    {
        StartCoroutine(GameTimer());
        UpdateScoreText();
    }

    IEnumerator GameTimer()
    {
        while (gameTime > 0)
        {
            yield return new WaitForSeconds(1f);// Pauses the coroutine for 1 second
            gameTime--;// Decreases the game time by 1 second
            UpdateTimerText(); // Updates the UI with the remaining time
        }
        GameOver();// Calls gameOver when the timer reaches zero
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + gameTime.ToString();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
    public void DeductScore(int points)
    {
        score -= points;
        UpdateScoreText();
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0; // Stop the game by setting time scale to zero
    }
}