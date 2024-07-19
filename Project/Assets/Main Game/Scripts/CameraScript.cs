using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset value to maintain a fixed distance from the player

    void Update()
    {
        // Set the camera's position to the player's position plus the offset
        transform.position = player.position + offset;
    }
}
