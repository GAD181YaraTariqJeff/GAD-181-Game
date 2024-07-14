using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losing : MonoBehaviour
{
    public event Action PlayerDied;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Anvil"))
        {
            PlayerDied.Invoke();
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }


}
