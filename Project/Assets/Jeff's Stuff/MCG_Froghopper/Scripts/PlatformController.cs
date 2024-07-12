using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.y <= 0f) 
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null ) 
            {
                Vector2 velocity = rb.velocity; 
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }


}
