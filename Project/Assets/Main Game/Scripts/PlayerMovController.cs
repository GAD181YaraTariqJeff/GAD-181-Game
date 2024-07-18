using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovController : MonoBehaviour
{
    public float speed = 8f;
    public float jumpPower = 16f;
    public Rigidbody2D rb;

    void Update()
    {
        // Move left and right
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Jump if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
