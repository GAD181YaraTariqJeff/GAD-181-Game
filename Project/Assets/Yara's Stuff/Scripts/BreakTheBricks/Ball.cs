 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    bool playing;
    bool spaceButtonClicked;
    public GameObject paddle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spaceButtonClicked = false;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playing = true;
            if(!spaceButtonClicked) 
            {
                rb.AddForce(Vector2.up * 500);
                spaceButtonClicked = true;
            }
            
        }
        if(!playing)
        {
            transform.position = new Vector2(paddle.transform.position.x, transform.position.y);
            
        }
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bottom"))
        {
            BreakTheBrick.ballIsAtBottomEdge = true;
            Debug.Log("The ball hits the bottom edge");
        }
    }
}
