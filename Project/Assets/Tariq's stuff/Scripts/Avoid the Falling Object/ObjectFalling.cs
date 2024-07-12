using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{
    float wait = 0.01f;
    public GameObject fallingObject;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(fallingObject, new Vector3(Random.Range(-10, 10), 4, 0), Quaternion.identity);
    }
}
