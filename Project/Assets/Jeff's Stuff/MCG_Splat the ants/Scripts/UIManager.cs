using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText; // Changed from livesText to timerText


    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTime(int lives)
    {
        timeText.text = "Lives Remaining: " + lives;
    }
}
