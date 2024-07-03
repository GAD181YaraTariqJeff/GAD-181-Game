using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 0;
    public Rigidbody2D rb;
    private bool isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.down * moveSpeed * Time.deltaTime);

    }
    private void OnMouseDown() {
        moveSpeed = 100f;
        LeaveThatPhone.numberOfCharacters--;
        if(LeaveThatPhone.numberOfCharacters == 0) {
            LeaveThatPhone.gameState = LeaveThatPhone.GameState.win;
        }
    }
    private void OnCollisionEnter2D() {
        
        rb.gravityScale = 10;
    }
}
