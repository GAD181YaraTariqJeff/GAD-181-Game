using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerWin();
        }
    }

    private void OnPlayerWin()
    {
        Debug.Log("You Win!");
        
    }

}
