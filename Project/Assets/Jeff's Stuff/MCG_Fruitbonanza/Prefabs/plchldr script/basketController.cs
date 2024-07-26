using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is dedicated for the control of the basket
/// </summary>
public class basketController : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        // Check for both D key and Right Arrow key to move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (tr.position.x < 8.5f) tr.position += new Vector3(0.5f, 0f, 0f);
        }

        // Check for both A key and Left Arrow key to move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (tr.position.x > -8.5f) tr.position += new Vector3(-0.5f, 0f, 0f);
        }

    }
}
