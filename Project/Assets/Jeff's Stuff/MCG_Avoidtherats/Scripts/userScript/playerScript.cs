using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is responsible for moving the character in the game it will have two functions
/// update will handle the user input, while the fixed update will be the responsible for moving
/// the actual player
/// </summary>
public class playerScript : MonoBehaviour
{
    //Make this visible in the inspector for easier fine tuning later on
    [SerializeField] private float mSpeed = 10f;

    public Rigidbody2D rBody2D;

    Vector2 mveMent;


    void Update()
    {
        mveMent.x = Input.GetAxisRaw("Horizontal");
        mveMent.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rBody2D.MovePosition(rBody2D.position + mveMent * mSpeed * Time.deltaTime);// Used time.delta time so the movespeed will be consistent
    }
}



