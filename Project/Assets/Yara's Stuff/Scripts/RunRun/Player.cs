using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float maxAcceleration = 10;  
    public float acceleration = 10;
    public float distance  = 0;
    public float jumpVelocity = 20;
    public float maxVelocity = 100; 
    public float groundHeight = -2 ;
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime =  0.4f; 
    public float holdJumpTimer =  0f; 
    public float jumpGroundThreshold = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Math.Abs(pos.y - groundHeight);
        //Debug.Log(groundDistance <=  jumpGroundThreshold);
        if(isGrounded || groundDistance <=  jumpGroundThreshold) 
        { 
            if(Input.GetKeyDown(KeyCode.Space)) {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true; 
                holdJumpTimer = 0f; 
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            isHoldingJump = false ;
        }
    }
    private void FixedUpdate() {
        Vector2 pos = transform.position;
        if(!isGrounded)
        {
            if(isHoldingJump) 
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if(holdJumpTimer >= maxHoldJumpTime) {
                       isHoldingJump = false;
                }
            }
            //Increment the player's position every frame  
            pos.y += velocity.y * Time.fixedDeltaTime;
            //adjust how the next frame will be able to get adjusted
            //so the player falls faster as it is falling
            if(!isHoldingJump) { //gravity only works if we are not holding the 
                                    //jump button
                velocity.y += gravity * Time.fixedDeltaTime;  
            }
            // Vector2 rayOrigine = new Vector2(pos.x + 0.7f, pos.y); 
            // Vector2 rayDirection = Vector2.up;
            
            // if(pos.y <= groundHeight)
            // {
            //     pos.y = groundHeight;
            //     isGrounded = true;
            // }
        }

        distance += velocity.x *  Time.fixedDeltaTime; 
         
        if(isGrounded) 
        {
            //As the character gains acceleration the ratio goes from  0 to 1 
            float velocityRatio = velocity.x / maxVelocity;
            
            
            //x acceleration will go from its max to 0
            acceleration = maxAcceleration * ( 1 - velocityRatio );

            velocity.x += acceleration * Time.deltaTime;

            if(velocity.x >= maxVelocity)
            {
                velocity.x = maxVelocity;
            } 
        }
        transform.position = pos; 
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 pos = transform.position;
        Debug.Log("Collision detected");
        pos.y = groundHeight;
        isGrounded = true;
    }
     
}
