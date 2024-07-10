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
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (tr.position.x < 8.5f) tr.position += new Vector3(0.5f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            if (tr.position.x > -8.5f) tr.position += new Vector3(-0.5f, 0f, 0f);
        }

    }
}
