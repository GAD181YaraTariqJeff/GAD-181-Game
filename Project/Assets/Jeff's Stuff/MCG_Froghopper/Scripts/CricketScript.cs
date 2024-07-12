using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
         Destroy(gameObject); // Optional: Destroy the cricket after it's collected
            Debug.Log("The Frog has eaten the Cricket!");
            Time.timeScale = 0;
        }
    }
}
