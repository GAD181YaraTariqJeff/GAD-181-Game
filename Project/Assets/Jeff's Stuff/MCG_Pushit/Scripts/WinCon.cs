using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{
    public GameObject winTextObject; // Reference to the text object that displays the win message

    void Start()
    {
        winTextObject.SetActive(false); // Hide the win message at the start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            winTextObject.SetActive(true); // Show the win message
            Time.timeScale = 0; // Pause the game
        }
    }
}

