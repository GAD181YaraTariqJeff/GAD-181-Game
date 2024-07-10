using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] GameObject cube;
	[SerializeField]public float shrinkRate = 0.5f;
	void Start () {
	 //whatever
	}
	
	// Update is called once per frame
	void Update () {
        float xScale = cube.transform.localScale.x;
		float originalSize = xScale;
        xScale -= shrinkRate * Time.deltaTime;
		float xPos = cube.transform.position.x - (originalSize - xScale) / 2;
		Vector2 max = Camera.main.ScreenToWorldPoint
                            (new Vector2(Screen.width, Screen.height));
		
        cube.transform.position = new Vector3(xPos , max.y -1.2f, cube.transform.position.z);
		cube.transform.localScale = new Vector3(xScale, cube.transform.localScale.y , cube.transform.localScale.z);
		// if(cube.transform.localScale.x <= 1) {
		// 	PopThemBalloons.gameOver = true;
		// }
	}
}
