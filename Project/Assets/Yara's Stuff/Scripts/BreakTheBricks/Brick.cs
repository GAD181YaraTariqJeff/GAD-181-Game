using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        BreakTheBrick.numberOfBricks--;
        Debug.Log("number of bricks is " + BreakTheBrick.numberOfBricks);
        
        Destroy(gameObject);
    }
}
