using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{
    public float walkingSpeed;

    public void Move(Vector3 direction)
    {
        transform.position += direction * walkingSpeed * Time.deltaTime;
    }

    public void ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}

