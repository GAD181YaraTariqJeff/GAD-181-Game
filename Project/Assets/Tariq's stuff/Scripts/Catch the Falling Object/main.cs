using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public Transform title;
    public Text scoreboard;


    void Start()
    {
        score = 0;
        GameOver = false;
        scoreboard.text = "0";
    }


    void Update()
    {
        if (GameOver == true)
        {
            title.localPosition = new Vector3(0f, 0f, 0f);
            GameOver = false;
        }
    }

    public void ScoreAdd()
    {
        score++;
        scoreboard.text = score.ToString();
    }

    public void Newgame()
    {
        SceneManager.LoadScene(0);
    }

}
