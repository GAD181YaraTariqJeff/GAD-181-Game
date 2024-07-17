using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyTimer : MonoBehaviour
{
    public float TotalTime;
    public TMP_Text TimeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime -= Time.deltaTime;
        if (TotalTime < 1)
        {
            TotalTime = 0;
            Time.timeScale = 0f;
            Debug.Log("Game over!");
        }
        TimeText.text = TimeText.ToString();
    }
}
