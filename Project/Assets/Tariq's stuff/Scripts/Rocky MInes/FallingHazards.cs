using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHazards : MonoBehaviour
{
    float wait = 0.1f;
    public GameObject fallingObject;

    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
    }

    void Fall()
    {
        Instantiate(fallingObject, new Vector3(Random.Range(-10, 10), 6, 0), Quaternion.identity);
    }

}
