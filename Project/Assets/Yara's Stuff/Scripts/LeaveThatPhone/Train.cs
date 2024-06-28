using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // Move left based on the time delta and speed
        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);

    // Get the screen boundaries
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float screenWidth = Screen.width;

    // If the mesh goes off the left side of the screen, stop its movement
        if (screenPos.x < 0)
            {
        // Optionally, you can disable the script or set the movement speed to zero
        // depending on your requirements.
        // For now, I'll just stop the movement:
            moveSpeed = 0f;
        }
    }
    private void OnCollisionEnter2D() {
        Debug.Log("The collision function is called");
        LeaveThatPhone.gameOver = true;
    }
}
