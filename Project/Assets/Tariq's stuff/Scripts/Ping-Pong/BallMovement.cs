using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float intialspeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text PLayerScore;
    [SerializeField] private Text AIScore;

    private int hitCounter;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 1f);
    }


    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, intialspeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (intialspeed + speedIncrease * hitCounter);
    }
        
    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 1f);
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection, yDirection;
        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        
        if(yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (intialspeed + (speedIncrease * hitCounter));


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI_Player")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x > 0)
        {
            ResetBall();
            PLayerScore.text = (int.Parse(PLayerScore.text) + 1).ToString();  
          
        }
        else if (transform.position.x < 0)
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }

}
