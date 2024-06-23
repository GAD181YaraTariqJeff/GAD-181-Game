using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is going to be used in one of the micro games and
/// if I like it I might reuse this script in other micro games but
/// for now this is just a simple script that ables the user to
/// move in a 2d manner.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    
    [SerializeField] private float speed = 8f;/* Keep this on serialize field so that it will be easier to adjust in in the inspector*/
    [SerializeField] private float jumpingPower = 16f;/* Keep this on serialize field so that it will be easier to adjust in in the inspector*/
    [SerializeField] private Rigidbody2D rb;

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // This allows the object to jump infinitely if you keep on pressing space
        if (Input.GetKeyDown (KeyCode.Space)) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }




}
