using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deadzone = -18;
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Debug.Log("Pipe is gone!");
            Destroy(gameObject);
        }
    }
}
