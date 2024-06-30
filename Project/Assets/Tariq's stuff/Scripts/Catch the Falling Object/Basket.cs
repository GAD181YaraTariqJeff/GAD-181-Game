using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
      if(Input.GetKey("right") == true)
      {
            if (tr.position.x < 7.8f) tr.position += new Vector3(0.2f, 0, 0); 
      }


      if (Input.GetKey("left") == true)
      {
            if (tr.position.x > -7.8f) tr.position += new Vector3(-0.2f, 0, 0);
      }
    }
}
