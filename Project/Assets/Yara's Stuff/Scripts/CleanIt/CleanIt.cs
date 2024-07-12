using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//using System.Numerics;
using UnityEngine;

public class CleanIt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mask;
    bool pressed;
    public static int nOfSquaresToTrigger = 42;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        if(pressed) 
        {
            GameObject obj = Instantiate(Mask, pos, Quaternion.identity);
            obj.transform.parent = GameObject.Find("GameManager").transform;
        }
        if(Input.GetMouseButton(0))
        {
            pressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
        if(nOfSquaresToTrigger == 0) {
            Debug.Log("you win!");
        }
    }
}
