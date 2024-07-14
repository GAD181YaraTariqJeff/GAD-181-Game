using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ControllingTheGame : MonoBehaviour
{
    public Canvas GameOverCanvas;
    public TMP_Text timertext;

    [SerializeField] private Losing playerController;

    public void Awake()
    {
        if(playerController != null)
        {
            playerController.PlayerDied += WhenPlayerDies;
        }

        if (GameOverCanvas.gameObject.activeSelf) //there's also "active in hirachy" code?!
        {
            GameOverCanvas.gameObject.SetActive(false);
        }
    }

    void WhenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);
        timertext.text = "You Lasted:" + Math.Round(Time.timeSinceLevelLoad, 2);
        

        if (playerController != null)
        {
            playerController.PlayerDied -= WhenPlayerDies;
        }
    }

    public void RetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f; 
    }
}
