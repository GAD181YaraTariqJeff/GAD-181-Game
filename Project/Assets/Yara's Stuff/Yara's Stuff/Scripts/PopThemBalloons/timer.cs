using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] GameObject cube;
	[SerializeField]public float growRate = -3f;
	void Start () {
	 //whatever
	}
	
	// Update is called once per frame
	// void Update () {
    //     float xScale = cube.transform.localScale.x;
    //     xScale += growRate * Time.deltaTime;
    //     cube.transform.position = new Vector3(cube.transform.position.x + (growRate * Time.deltaTime) /2,  cube.transform.position.y,  cube.transform.position.z);
	// 	cube.transform.localScale  = new Vector3(xScale, cube.transform.localScale.y , cube.transform.localScale.z);
	// }
}
