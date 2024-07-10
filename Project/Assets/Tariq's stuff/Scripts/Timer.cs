using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float gameTime;
    public Text gameText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime < 1)
        {
            gameTime = 0;
            Time.timeScale = 0f;
            Debug.Log("Game over!");
        }
        gameText.text = gameTime.ToString();
    }
}
