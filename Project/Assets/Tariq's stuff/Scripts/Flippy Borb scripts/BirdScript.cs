using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapstrength;
    public LogicScript logic;
    public bool BirdIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapstrength;
        }

        transform.Rotate(new Vector3(0, 0, 1));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameover();
        BirdIsAlive = false;
    }
}
