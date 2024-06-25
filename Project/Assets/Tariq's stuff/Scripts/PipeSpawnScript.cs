using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnrate =2f;
    private float timer =0f;
    public float HightOffSet = 10f;

    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }
        else 
        {
            spawnPipe();
            timer = 0;
        }
        
    }
    void spawnPipe()
    {
        float LowestPoint = transform.position.y - HightOffSet;
        float HighestPoint = transform.position.y + HightOffSet;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(LowestPoint, HighestPoint), 0), transform.rotation);
    }
}
