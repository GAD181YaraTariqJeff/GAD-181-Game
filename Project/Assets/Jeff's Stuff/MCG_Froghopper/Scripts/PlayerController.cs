using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private float moveX;
    public float fallThreshold = -10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        // Check if the player has fallen below the threshold
        if (transform.position.y <= fallThreshold)
        {
            GameOver();
        }
        
    }
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
    void GameOver()
    {
        Debug.Log("Game Over: Player has fallen below the threshold.");
        Time.timeScale = 0; // This stops the game
    }
}
