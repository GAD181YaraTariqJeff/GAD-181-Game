using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float moveSpeed = 100f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float screenWidth = Screen.width;

    
        if (screenPos.x < 0)
        {
         moveSpeed = 0f; 
        }
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     LeaveThatPhone.gameState = LeaveThatPhone.GameState.loose;
    //     moveSpeed = 0f;
        
    // }
    private void OnCollisionEnter2D() {
        LeaveThatPhone.gameState = LeaveThatPhone.GameState.loose;
        moveSpeed = 0f;
    }
}
